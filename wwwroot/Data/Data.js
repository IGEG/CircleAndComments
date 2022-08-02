console.log("data");
class Data {
    constructor(url) { this.url = url; }
   
// Метод  GetAll

    getAllCircle() {
        $.ajax({
            url: this.url, method: "GET", dataType: "json", success: function (data) {
                var width = window.innerWidth;
                var height = window.innerHeight;
                var stage = new Konva.Stage({ container: 'container', width: width, height: height, });
                var layer = new Konva.Layer();

// for по массиву кругов

                for (var i = 0; i < data.length; i++) {

//группа объектов

                    var group = new Konva.Group({});

// создем объект Circle. метод getCircle() возвращает  Konva.Circle

                    const newCircle = new Circle(data[i].CircleId, data[i].PointX, data[i].PointY, data[i].Radius, data[i].Color);
                    var circle = newCircle.getCircle();
                    group.add(circle);
                    var Textheight = 20;

// for по массиву комментариев к каждому кругу

                    for (var j = 0; j < data[i].CommentsInCircle.length; j++) {

// создем объект Text. метод getText() возвращает  Konva.Text

                        Textheight = Textheight + 35;
                        const newText = new Text(data[i].PointX, (data[i].PointY + Textheight), data[i].CommentsInCircle[j].Text);
                        var text = newText.getText();

                        text.offsetX(text.width() / 2);

                        var widthRectangle = text.width();
                        var heightRectangle = text.height();

                        const newRectangle = new Rectangle(data[i].PointX, (data[i].PointY + Textheight), data[i].CommentsInCircle[j].Color, widthRectangle, heightRectangle);
                        var rectangle = newRectangle.getRectangle();

                        rectangle.offsetX(rectangle.width() / 2);

                        //добавляем в группу text и rectangle

                        group.add(rectangle);
                        group.add(text);
                    }
                    layer.add(group);
                    stage.add(layer);
                }
            }
        });  
    }

// Метод  Delete

    deleteCircle(Id) {
    $.ajax({
        url: this.url +'/' + Id,
        method: 'DELETE',
        success: function () {
            alert('круг удален!');

        },
        error: function (error) {
            alert(error);
        }
    })
    }
}

