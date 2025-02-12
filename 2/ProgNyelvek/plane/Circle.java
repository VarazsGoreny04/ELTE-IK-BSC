package plane;

public class Circle
{
    double x, y, r;

    public void getter()
    {
        
    }

    public void setter(double x, double y, double r)
    {
        if (r < 0)
            throw new IllegalArgumentException("The radius must be greater than zero!");

        this.x = x;
        this.y = y;
        this.r = r;
    }
}