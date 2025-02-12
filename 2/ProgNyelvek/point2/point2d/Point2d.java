package point2.point2d;

public class Point2d {
    int x;
    int y;

    public Point2d(int x, int y) {
        this.x = x;
        this.y = y;
    }

    @Override
    public String toString() {
        return "(" + x + ", " + y + ")";
    }
}