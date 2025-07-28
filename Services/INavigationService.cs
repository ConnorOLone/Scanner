namespace Scanner.Services;

public interface INavigationService
{
    public Task Logon();

    public Task Logout();

    public Task GoToPage(string url);

    public Task InitMain();
}