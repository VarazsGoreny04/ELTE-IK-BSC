class Main
{
    public static void main(String[] args)
    {
        Point p1 = new Point(0d, 0d);
        System.out.println(p1.x + " : " + p1.y);

        p1.move(1d, 1d);
        System.out.println(p1.x + " : " + p1.y);

        p1.mirror(3d, 3d);
        System.out.println(p1.x + " : " + p1.y);

        p1.mirror(new Point(3d, 3d));
        System.out.println(p1.x + " : " + p1.y);
        
        System.out.println(p1.distance(new Point(0d, 0d)));
    }
}