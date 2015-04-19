
public class Fibonacci {
	public static void main(String[] args) {
		long ns = System.nanoTime();
		new Fibonacci().start();
		long time = (System.nanoTime() - ns)/1000000;
		System.out.println(time + "ms");
	}
	
	public void start() {
		fibonacci(40);
	}
	
	public long fibonacci(int n) {
		if (n == 0)
			return 0;
		else if (n == 1)
			return 1;
		else
			return fibonacci(n-1) + fibonacci(n-2);
	}
}
