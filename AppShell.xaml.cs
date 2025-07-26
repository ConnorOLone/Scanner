using Scanner.Views;

namespace Scanner;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(TrackBoxMenuPage), typeof(TrackBoxMenuPage));
        Routing.RegisterRoute(nameof(MoveBoxPage), typeof(MoveBoxPage));
        Routing.RegisterRoute(nameof(MoveItemPage), typeof(MoveItemPage));
        Routing.RegisterRoute(nameof(CheckLocationPage), typeof(CheckLocationPage));
        Routing.RegisterRoute(nameof(DispatchItemsPage), typeof(DispatchItemsPage));
        Routing.RegisterRoute(nameof(ReturnItemsPage), typeof(ReturnItemsPage));
        
    }
}