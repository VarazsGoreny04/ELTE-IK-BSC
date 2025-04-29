package gy3;

public class ropi {
	public static void main(String[] args){
		Thread firstthread = new Thread(() -> {
			for (int i = 1; i <= 100; ++i) {
			System.out.print(i + " ");
			}
			});
			firstthread.run();
			
			new Thread(() -> {
			for (int i = 1; i <= 100; ++i) {
			System.out.print(i + " ");
			System.out.print(-i + " ");
			}
			
			}).run();
	}

	public static synchronized void Alma(){
		
	}
}
