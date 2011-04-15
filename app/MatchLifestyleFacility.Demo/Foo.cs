using System;

namespace ConsoleApplication1
{
	public class Foo : IFoo
	{
		public void PrintInstanceHashCode()
		{
			Console.WriteLine(GetHashCode());
		}
	}
}