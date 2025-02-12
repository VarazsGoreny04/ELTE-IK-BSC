namespace Formula1
{
	public abstract class People
	{
        public string name;
		public int age;

        public People(string name, int age)
        {
            this.name = name;
            this.age = age; 
        }
    }

    public class Pilot : People
    {
        public int speed;

        public Pilot(string name, int age, int speed) : base(name, age)
        {
            this.name = name;
            this.age = age;
            this .speed = speed;
        }
    }
}
