package app;

import java.util.List;
import java.util.ArrayList;
import commerce.company.Company;
import commerce.company.PublicTransportCompany;

class Register {
	public static void main(String[] args) {
		List<Company> companies = new ArrayList<Company>();
		for (String param : args) {
			companies.add(PublicTransportCompany.createFromString(param));
		}
		System.out.println(companies.size());
		for (Company com : companies) {
			System.out.println(com.toString());
		}
	}
}