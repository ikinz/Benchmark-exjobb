using System;

namespace TestFibonacci
{
	public class Fibonacci
	{
		static void Main() {
			new Fibonacci ().start();
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

