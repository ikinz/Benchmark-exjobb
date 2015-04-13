import java.io.*;

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
		new TestIO().start(file, output);
		long time = (System.nanoTime() - ns)/1000000;
		System.out.println(time + "ms");
	}

	public void start(String file, String output) {
		try {
			BufferedReader br = new BufferedReader
				(new InputStreamReader(new FileInputStream(file)));
			BufferedWriter bw = new BufferedWriter
				(new OutputStreamWriter(new FileOutputStream(output)));

			String line;

			while ((line = br.readLine()) != null) {
				line = line.replace("Tellus", "Terra");
				line = line.replace("tellus", "Terra");

				bw.append(line + "\n");
			}

			br.close();
			bw.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
