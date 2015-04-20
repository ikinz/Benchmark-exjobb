import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
 
public class LZW {
    /** Compress a string to a list of output symbols. */
    public static List<Integer> compress(String uncompressed) {
        // Build the dictionary.
        int dictSize = 256;
        Map<String,Integer> dictionary = new HashMap<String,Integer>();
        for (int i = 0; i < 256; i++)
            dictionary.put("" + (char)i, i);
 
        String w = "";
        List<Integer> result = new ArrayList<Integer>();
        for (char c : uncompressed.toCharArray()) {
            String wc = w + c;
            if (dictionary.containsKey(wc))
                w = wc;
            else {
                result.add(dictionary.get(w));
                // Add wc to the dictionary.
                dictionary.put(wc, dictSize++);
                w = "" + c;
            }
        }
 
        // Output the code for w.
        if (!w.equals(""))
            result.add(dictionary.get(w));
        return result;
    }
 
    /** Decompress a list of output ks to a string. */
    public static String decompress(List<Integer> compressed) {
        // Build the dictionary.
        int dictSize = 256;
        Map<Integer,String> dictionary = new HashMap<Integer,String>();
        for (int i = 0; i < 256; i++)
            dictionary.put(i, "" + (char)i);
 
        String w = "" + (char)(int)compressed.remove(0);
        StringBuffer result = new StringBuffer(w);
        for (int k : compressed) {
            String entry;
            if (dictionary.containsKey(k))
                entry = dictionary.get(k);
            else if (k == dictSize)
                entry = w + w.charAt(0);
            else
                throw new IllegalArgumentException("Bad compressed k: " + k);
 
            result.append(entry);
 
            // Add w+entry[0] to the dictionary.
            dictionary.put(dictSize++, w + entry.charAt(0));
 
            w = entry;
        }
        return result.toString();
    }
 
    public static void main(String[] args) throws IOException {
    	String file = "dump.txt";
		for (int i = 0; i < args.length; i++) {
			if (args[i].equals("-f")) {
				file = args[++i];
			}
		}
    	
        List<Integer> compressed = compress(ReadAll.readAllLines(file));
        String decompressed = decompress(compressed);
        System.out.println(decompressed);
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