using Castle.Windsor;
using Castle.Windsor.Installer;
using KkozmicDemos;

namespace ConsoleApplication1
{
	internal class Program
	{
		private static void Main()
		{
			using (var container = new WindsorContainer(new CustomProxyFactory()))
			{
				container.Install(FromAssembly.This());
				var foo = container.Resolve<IFoo>();
				foo.PrintInstanceHashCode();
				foo.PrintInstanceHashCode();
				foo.PrintInstanceHashCode();
			}
		}
	}
}