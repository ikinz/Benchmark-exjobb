
public class TestIO {
	public static void main(String[] args) {
		String file = "dump.txt";
		String output = "res.txt";
		for (int i = 0; i < args.length; i++) {
			if (args[i].equals("-f")) {
				file = args[++i];
			} else if (args[i].equals("-o")) {
				output = args[++i];
			}
		}
		
		long ns = System.nanoTime();
		new TestIO().start();
		System.out.println(System.nanoTime() - ns);
	}
	
	public void start() {
		
	}
}
