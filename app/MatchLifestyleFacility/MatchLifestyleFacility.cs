using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Proxy;
using Castle.MicroKernel.Registration;

namespace KkozmicDemos
{
	public class MatchLifestyleFacility : AbstractFacility
	{
		protected override void Init()
		{
			Kernel.Register(Component.For<UseDifferentTargetInterceptor>());
			Kernel.ComponentRegistered += Kernel_ComponentRegistered;
		}

		private void Kernel_ComponentRegistered(string key, IHandler handler)
		{
			if (handler.ComponentModel.ExtendedProperties.InnerComponentName() == null)
			{
				return;
			}
			var options = ProxyUtil.ObtainProxyOptions(handler.ComponentModel, createOnDemand: false);
			if (options == null)
			{
				return;
			}
			options.OmitTarget = false;
			options.AllowChangeTarget = true;
		}
	}
}