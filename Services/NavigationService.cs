using Scanner.Views;

namespace Scanner.Services;

public class NavigationService : INavigationService
{
    private AppShell shell;

    public NavigationService()
    {
        shell = new AppShell();
    }

    public async Task GoToPage(string url)
    {
        await shell.GoToAsync(url);
    }

    public async Task Logon()
    {
        App.Current.MainPage = shell;
        await shell.GoToAsync(nameof(LoginView));
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }

    public async Task InitMain()
    {
        App.Current.MainPage = shell;

        return;
    }
}