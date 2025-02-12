package commerce.company;

public abstract class Company {
	int establishmentYear;
	String name;

	public int GetEstablishmentYear() {
		return establishmentYear;
	}

	public String GetName() {
		return name;
	}

	public Company(String name, int establishmentYear) {
		this.name = name;
		this.establishmentYear = establishmentYear;
	}
}