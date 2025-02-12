class Hello_World
{
    public static void main(String[] args)
    {
        System.out.println("Hello World!");
        for (int i = 1; i < 11; ++i)
        {
            for (int j = 1; j < 11; ++j)
            {
                if (i * j < 10)
                    System.out.print(" ");
                System.out.print(i * j + " ");
            }
            System.out.println();
        }
        Wizard.Spell();
        System.out.println(Wizard.name = "Bruh");
        String[] nemtom = {"Tom", "Tom"};
        System.out.println(nemtom[1].charAt(0));
        double a = 1.1;
        int b = 2;
        System.out.println(b+a);
    }
}

class Wizard
{
    public static String name = "Magikus Miki";
    public static int age = 999;

    public static void Spell()
    {
        System.out.println("Abrakadabra!");
    }
}