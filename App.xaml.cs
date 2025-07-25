namespace Scanner;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var shell = new AppShell();
        var window = new Window(shell);
        
        window.Created += async (s, e) =>
        {
            await shell.GoToAsync("//login");
        };
        
        return window;
    }
}