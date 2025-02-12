class Point
{
    public double x;
    public double y;

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public void move(double dx, double dy)
    {
        this.x += dx;
        this.y += dy;
    }

    public void mirror(double ox, double oy)
    {
        move(2 * (ox - this.x), 2 * (oy - this.y));
    }

    public void mirror(Point o)
    {
        move(2 * (o.x - this.x), 2 * (o.y - this.y));
    }

    public double distance(Point o)
    {
        return Math.hypot(o.x - this.x,o.y - this.y);
    }
}