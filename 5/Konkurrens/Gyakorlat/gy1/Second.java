public class Second {
	public static void main(String[] args) {
		for (int i = 0; i < args.length; ++i) {
			int num = i;
			Thread t = new Thread(() -> {
				System.out.print(args[num] + " " + num + ", ");
			});
			t.start();
		}
	}
}
