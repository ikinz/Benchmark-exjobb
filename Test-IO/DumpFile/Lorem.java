import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;


public class Lorem {
	public static void main(String[] args) {
		long time = System.currentTimeMillis();
		new Lorem().start();
		System.out.println((System.currentTimeMillis() - time) + "ms");
	}
	
	public void start() {
		String[] lorem = new String[41];
		
		BufferedReader br = new BufferedReader(new InputStreamReader(this.getClass().getResourceAsStream("/lorem")));
		try {
			String line;
			int counter = 0;
			while((line = br.readLine()) != null) {
				lorem[counter] = line;			
				counter++;
			}
			
			BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(new FileOutputStream("dump.txt"), "utf-8"));
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < 1000000; i++) {
				builder.append(lorem[i%lorem.length]);
				builder.append(System.getProperty("line.separator"));
			}
			bw.write(builder.toString());
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
