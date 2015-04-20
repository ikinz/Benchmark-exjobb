using System;
using System.Diagnostics;

namespace TestFibonacci
{
	public class Fibonacci
	{
		static void Main() {
			//Console.WriteLine(GC.GetTotalMemory (true));
			Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess ().WorkingSet64);
			new Fibonacci ().start();
			Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess ().WorkingSet64);
			Console.WriteLine(GC.GetTotalMemory (true));
		}

		public void start() {
			fibonacci (40);
		}

		public long fibonacci(int n) {
			if (n == 0)
				return 0;
			else if (n == 1)
				return 1;
			else
				return fibonacci (n - 1) + fibonacci (n - 2);
		}
	}
}

