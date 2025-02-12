class Ropi1
{
    public static void main(String args[])
    {
        System.out.println("Adjon meg egy szamot:");
        int a = Integer.parseInt(System.console().readLine());
        System.out.println("Adjon meg meg egy szamot:");
        int b = Integer.parseInt(System.console().readLine());
        System.out.println("A ket szam osszege: " + (a + b));
    }
}