class Greet1
{
    public static void main(String[] args)
    {
        String name = System.console().readLine();
        System.console().printf("Hello %s!\n", name);
    }
}