class Print
{
    public static void main(String[] args)
    {
        if (args.length < 2)
            return;

        int num1 = Integer.parseInt(args[0]), num2 = Integer.parseInt(args[1]);
        System.out.println(num1 + num2);

        for (int i = 0; i <= num2; ++i)
            System.out.println(i / 2d);
    }
}