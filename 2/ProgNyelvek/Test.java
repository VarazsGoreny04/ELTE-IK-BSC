public class Test {
    public static void main(String[] args) {
        final char[] one = { 'n', 'e', 'm' };
        char[] two = one;
        System.out.println(one.equals(two));
        one[1] = 'i';
        System.out.println(two);
        System.out.println(one);
        alma();
    }

    public static void alma() {
        main(null);
    }
}