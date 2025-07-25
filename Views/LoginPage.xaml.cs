namespace Scanner.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(UsernameEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please enter both username and password.", "OK");
            return;
        }

        LoginButton.IsEnabled = false;
        LoginButton.Text = "Signing In...";

        await Task.Delay(1000);

        await Shell.Current.GoToAsync("//mainmenu");

        LoginButton.IsEnabled = true;
        LoginButton.Text = "Sign In";
    }

    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Forgot Password", "Please contact your system administrator to reset your password.", "OK");
    }
}