using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Scanner.Services;
using Scanner.ViewModels;
using Scanner.Views;
using ZXing.Net.Maui.Controls;

namespace Scanner;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        AddViewModels(builder.Services);
        AddViews(builder.Services);
        AddServices(builder.Services);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddSingleton(typeof(INavigationService), typeof(NavigationService));
    }

    private static void AddViews(IServiceCollection services)
    {
        services.AddSingleton(typeof(LoginView));
        services.AddSingleton(typeof(MainMenuView));
        services.AddSingleton(typeof(SettingsView));
        services.AddTransient(typeof(ScanView));

        services.AddTransient(typeof(CheckBoxLocationView));
        services.AddTransient(typeof(DispatchItemsView));
        services.AddTransient(typeof(MoveBoxView));
        services.AddTransient(typeof(MoveItemView));
        services.AddTransient(typeof(ReturnItemsView));
        services.AddTransient(typeof(TrackBoxMenuView));
    }

    private static Task AddViewModels(IServiceCollection services)
    {
        services.AddScoped(typeof(LoginViewModel));
        services.AddSingleton(typeof(MainMenuViewModel));

        return Task.CompletedTask;
    }
}