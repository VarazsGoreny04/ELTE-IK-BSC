class Person
{
    public String name;
    private int age;

    public Person(String name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void setAge(int age)
    {
        if (age >= 0)
            this.age = age;
        else
            throw new IllegalArgumentException("Ne legyel balfasz! Hogy lehetne mar negativ szam???");
    }

    public int getAge()
    {
        return this.age;
    }
}