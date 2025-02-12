package animal;

class Main {
    public static void main(String[] args) {
        Animal cat = new Cat();
        cat.makeNoise();
    }
}

class Animal {
    public void makeNoise() {
        System.out.println("general animal noise");
    }
}

class Cat extends Animal {
    @Override
    public void makeNoise() {
        System.out.println("meow");
    }
}

class Dog extends Animal {
    @Override
    public void makeNoise() {
        System.out.println("woof");
    }
}
