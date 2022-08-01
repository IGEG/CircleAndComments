let messageText = "circle";
console.log(messageText);
class Circle {
    constructor(x, y, radius, fill) {
        this.x = x;
        this.y = y;
        this.radius = radius;
        this.fill = fill;
    }
    getCircle() {
        var circle = new Konva.Circle({ x: this.x, y: this.y, radius: this.radius, fill: this.fill });
        return circle;
    }
}

