package commerce.company;

import java.util.List;
import java.util.Arrays;

public class PublicTransportCompany extends Company {
	private List<String> places;

	public PublicTransportCompany(String name, int establishmentYear, List<String> places) {
		super(name, establishmentYear);
		this.places = places;
	}

	public String toString() {
		StringBuilder str = new StringBuilder();
		str.append(establishmentYear + ":").append(name + ":");
		str.append(places.get(0));
		for (int i = 1; i < places.size(); ++i) {
			str.append("," + places.get(i));
		}
		return str.toString();
	}

	public static PublicTransportCompany createFromString(String data) {
		String[] tokens = data.split(":");
		return new PublicTransportCompany(tokens[0], Integer.parseInt(tokens[1]), Arrays.asList(tokens[2].split(",")));
	}
}