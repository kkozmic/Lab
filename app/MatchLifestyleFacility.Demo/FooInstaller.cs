using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KkozmicDemos;

namespace ConsoleApplication1
{
	public class FooInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.AddFacility<MatchLifestyleFacility>();
			container.Register(Component.For<IFoo>().MatchLifestyleTo("inner"),
			                   Component.For<IFoo>().ImplementedBy<Foo>().Named("inner").LifeStyle.Transient
				);
		}
	}
}