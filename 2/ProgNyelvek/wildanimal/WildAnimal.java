package wildanimal;

public enum WildAnimal {
    MONKEY(4, "Monkey"),
    GIRAFFE(12, "Giraffe"),
    ELEPHANT(30, "Elephant");

    public int foodRequirement;
    public String name;

    WildAnimal(int foodRequirement, String name) {
        this.foodRequirement = foodRequirement;
        this.name = name;
    }

    public void printFoodRequirement() {
        System.out.println(this.name + " eats " + this.foodRequirement + " amount of food.");
    }
}