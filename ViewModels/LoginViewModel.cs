using CommunityToolkit.Mvvm.Input;

namespace Scanner.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    [RelayCommand]
    public void Login()
    {
        try
        {
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}

