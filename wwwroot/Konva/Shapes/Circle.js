console.log("circle");

class Circle {
    constructor(Id, x, y, radius, fill) {
        this.Id = Id;
        this.x = x;
        this.y = y;
        this.radius = radius;
        this.fill = fill;
    }
    getCircle() {
        var circle = new Konva.Circle({ x: this.x, y: this.y, radius: this.radius, fill: this.fill, Id: this.Id });
        return circle;
    }
}

