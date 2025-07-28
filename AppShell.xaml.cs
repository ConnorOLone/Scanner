using Scanner.Views;

namespace Scanner;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
        Routing.RegisterRoute(nameof(TrackBoxMenuView), typeof(TrackBoxMenuView));
        Routing.RegisterRoute(nameof(MoveBoxView), typeof(MoveBoxView));
        Routing.RegisterRoute(nameof(MoveItemView), typeof(MoveItemView));
        Routing.RegisterRoute(nameof(CheckLocationView), typeof(CheckLocationView));
        Routing.RegisterRoute(nameof(DispatchItemsView), typeof(DispatchItemsView));
        Routing.RegisterRoute(nameof(ReturnItemsView), typeof(ReturnItemsView));
    }

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        string local = args.Current.Location.ToString();
        if ( local.Contains("ScanView") )
        {
            ScanView.RecreateMainPage();
        }
        base.OnNavigated(args);
    }
}