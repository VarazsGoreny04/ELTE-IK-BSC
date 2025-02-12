package plane;

public class PublicCircle {
    public double x = 0, y = 0, r = 1;

    PublicCircle(double x, double y, double r) {
        this.x = x;
        this.y = y;
        this.r = r;
    }

    public double getArea() {
        return Math.pow(r, 2) * Math.PI;
    }
}