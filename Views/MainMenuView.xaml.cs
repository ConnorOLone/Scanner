using Scanner.ViewModels;

namespace Scanner.Views;

public partial class MainMenuView : ContentPage
{
    public MainMenuView(MainMenuViewModel vm)
    {
        InitializeComponent();

        this.BindingContext = vm;
    }
}