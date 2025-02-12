class Main
{
    public static void main(String[] args)
    {
        Person p1 = new Person("John", 32);
        Person p2 = new Person("Kate", 24);

        p1.setAge(-3);
        p1.setAge(69);

        System.out.println(p1.getAge() <= p2.getAge() ? p1.name :  p2.name);
    }
}