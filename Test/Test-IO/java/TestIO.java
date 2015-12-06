import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

		//long ns = System.nanoTime();
		new TestIO().start(file, output);
		//long time = (System.nanoTime() - ns)/1000000;
		//System.out.println(time + "ms");
	}

	public void start(String file, String output) {
		/*
		String txt = "";
		try {
			File f = new File(file);
			FileInputStream inp = new FileInputStream(f);
			byte[] bf = new byte[(int)f.length()];
			inp.read(bf);
			txt = new String(bf, "UTF-8");
		} catch (Exception e) {
			
		}
		*/
		try {
			String txt = ReadAll.readAllLines(file);
			String[] arr = txt.split("\n");
			for (int i = 0; i < arr.length; i++) {
				arr[i] = arr[i].replace("Tellus", "Terra");
				arr[i] = arr[i].replace("tellus", "terra");
			}
			String.join("\n", arr);
			ReadAll.writeAllLines(output, );
		} catch (Exception e) {
			
		}
		
		
		/*
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
		*/
	}
	
	private static class ReadAll {
		public static String readAllLines(String filename) throws IOException {
			Path file = Paths.get(filename);
			StringBuilder res = new StringBuilder();
			for (String s : Files.readAllLines(file, Charset.defaultCharset()))
				res.append(s);
			
			return res.toString();
		}
		public static void writeAllLines(String file, String content) throws IOException {
			Path f = Paths.get(file);
			Files.write(f, content.getBytes());
		}
	}
}
