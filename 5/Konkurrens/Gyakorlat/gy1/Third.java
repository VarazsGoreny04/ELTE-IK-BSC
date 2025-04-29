import java.lang.Thread;

public class Third {
	public static void main(String[] args) {
		for (int i = 0; i < args.length; ++i) {
			int num = i;
			Thread t = new Thread(() -> {
				fakePrintln(args[num] + " " + (num + 1) + ", ");
			});
			t.start();
		}
	}

	public static void fakePrintln(String word) {
		for (int i = 0; i < word.length(); ++i)
			System.out.print(word.charAt(i));
	}
}
