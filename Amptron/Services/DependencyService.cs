using System;
namespace Amptron.Services
{
    public static class DependencyService
    {
        public static bool IsTablet => DeviceInfo.Current.Idiom == DeviceIdiom.Tablet;

        public static IServiceProvider Current =>
#if ANDROID
            MauiApplication.Current.Services;
#elif WINDOWS
            MauiWinUIApplication.Current.Services;
#else
            MauiUIApplicationDelegate.Current.Services;
#endif

        private static IServiceScope scope;

        /// <summary>
        /// Registers the service provider and creates a dependency scope
        /// </summary>
        /// <param name="sp"></param>
        public static void RegisterServiceProvider(IServiceProvider sp)
        {
            scope = sp.CreateScope();
        }

        /// <summary>
        /// Returns a resolved instance of the requested type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>() where T : class
        {
            var result = scope.ServiceProvider.GetService<T>();
            return result;
        }

        public static object Resolve(Type serviceType)
        {
            var result = scope.ServiceProvider.GetRequiredService(serviceType);
            return result;
        }
    }
}

