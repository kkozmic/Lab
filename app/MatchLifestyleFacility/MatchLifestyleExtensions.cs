using System.Collections;
using Castle.MicroKernel.Registration;

namespace KkozmicDemos
{
	public static class MatchLifestyleExtensions
	{
		private const string key = "castle-match.lifestyle.inner.component.name";

		internal static string InnerComponentName(this IDictionary componentModelExtendedProperties)
		{
			return (string) componentModelExtendedProperties[key];
		}

		public static ComponentRegistration<TService> MatchLifestyleTo<TService>(
			this ComponentRegistration<TService> registration, string otherComponentName)
		{
			return registration.ExtendedProperties(Property.ForKey(key).Eq(otherComponentName))
				.Interceptors<UseDifferentTargetInterceptor>();
		}
	}
}