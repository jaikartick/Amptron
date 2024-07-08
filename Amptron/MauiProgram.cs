using Amptron.Controls;
using Amptron.Helpers;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Microcharts.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using DependencyService = Amptron.Services.DependencyService;

namespace Amptron;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCompatibility()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
			.UseMicrocharts()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
				fonts.AddFont("Poppins-Medium.ttf", "PoppinsMedium");
				fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
				fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");
			}).ConfigureMauiHandlers(handlers =>
			{
#if IOS
                handlers.AddCompatibilityRenderer(typeof(BorderlessEntry), typeof(Amptron.Platforms.iOS.Renderers.BorderlessEntryRenderer));
#else
                handlers.AddCompatibilityRenderer(typeof(BorderlessEntry), typeof(Amptron.Platforms.Android.Renderers.BorderlessEntryRenderer));
#endif
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
        CompositionRoot.GetServices(builder.Services);
        MauiApp mauiApp = builder.Build();
        DependencyService.RegisterServiceProvider(mauiApp.Services.GetService<IServiceProvider>());
		return mauiApp;
	}
}

