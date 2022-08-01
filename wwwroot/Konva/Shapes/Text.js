let message = "text";
console.log(message);

class Text {
    constructor(x, y, text) {
        this.x = x;
        this.y = y;
        this.text = text;
    }
    getText() {

        var text = new Konva.Text({ x: this.x, y: this.y, text: this.text, fontSize: 30, fontFamily: 'Calibri', fill: 'green', });
          
        return text;
    }
}

