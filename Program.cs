using System;

namespace TrippyTest
{
	class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				var test = new TrippyTest();
				test.Run();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}
