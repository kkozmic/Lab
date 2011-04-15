using Castle.Core;
using Castle.MicroKernel;
using Castle.Windsor.Proxy;

namespace KkozmicDemos
{
	public class CustomProxyFactory : DefaultProxyFactory
	{
		public override bool RequiresTargetInstance(IKernel kernel, ComponentModel model)
		{
			return base.RequiresTargetInstance(kernel, model) && model.ExtendedProperties.InnerComponentName() == null;
		}
	}
}