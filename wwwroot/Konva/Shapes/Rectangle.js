let mess = "rect";
console.log(mess);

class Rectangle {
    constructor(x, y, fill, width, height) {
        this.x = x;
        this.y = y;
        this.fill = fill;
        this.width = width;
        this.height = height;
    }
    getRectangle() {

        var rectangle = new Konva.Rect({
            x: this.x,
            y: this.y,
            stroke: '#555',
            strokeWidth: 1,
            fill: this.fill,
            width: this.width,
            height: this.height });

        return rectangle;
    }
}
