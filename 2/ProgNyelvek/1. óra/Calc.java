class Calc {
    public static void main(String[] args) {
        if (args.length != 2)
            return;

        int num1 = Integer.parseInt(args[0]);
        int num2 = Integer.parseInt(args[1]);

        System.out.println(num1 + " + " + num2 + " = " + (num1 + num2));
        System.out.println(num1 + " - " + num2 + " = " + (num1 - num2));
        System.out.println(num1 + " * " + num2 + " = " + (num1 * num2));
        if (num2 != 0) {
            System.out.println(num1 + " / " + num2 + " = " + ((double) num1 / num2));
            System.out.println(num1 + " % " + num2 + " = " + (num1 % num2));
        }
    }
}