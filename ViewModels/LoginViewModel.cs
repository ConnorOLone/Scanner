using CommunityToolkit.Mvvm.Input;
using Scanner.Services;

namespace Scanner.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    public LoginViewModel(INavigationService navigationService) : base(navigationService)
    {
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        try
        {
            NavigationService.InitMain();
        }
        catch ( Exception e )
        {
            Console.WriteLine(e);
            throw;
        }
    }
}