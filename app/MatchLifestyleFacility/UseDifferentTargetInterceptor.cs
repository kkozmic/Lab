using Castle.Core;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using Castle.MicroKernel;

namespace KkozmicDemos
{
	[Transient]
	public class UseDifferentTargetInterceptor : IInterceptor, IOnBehalfAware
	{
		private readonly IKernel kernel;
		private string innerComponentName;

		public UseDifferentTargetInterceptor(IKernel kernel)
		{
			this.kernel = kernel;
		}

		public void Intercept(IInvocation invocation)
		{
			var changeInvocationTarget = (IChangeProxyTarget) invocation;
			var inner = default(object);
			try
			{
				inner = kernel.Resolve<object>(innerComponentName);
				changeInvocationTarget.ChangeInvocationTarget(inner);
				invocation.Proceed();
			}
			finally
			{
				kernel.ReleaseComponent(inner);
			}
		}

		public void SetInterceptedComponentModel(ComponentModel target)
		{
			innerComponentName = target.ExtendedProperties.InnerComponentName();
		}
	}
}