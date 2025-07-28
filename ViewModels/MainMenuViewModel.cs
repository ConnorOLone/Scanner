using CommunityToolkit.Mvvm.Input;
using Scanner.Services;
using Scanner.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.ViewModels;

public partial class MainMenuViewModel : ViewModelBase
{
    private INavigationService navigationService;

    public MainMenuViewModel(INavigationService navigationService) : base(navigationService)
    {
        this.navigationService = navigationService;
    }

    [RelayCommand]
    private void MoveItem()
    {
        navigationService.GoToPage(nameof(MoveItemView));
    }

    [RelayCommand]
    private async Task CheckLocationAsync()
    {
        await navigationService.GoToPage(nameof(CheckLocationView));
    }

    [RelayCommand]
    private async Task DispatchItemsAsync()
    {
        await navigationService.GoToPage(nameof(DispatchItemsView));
    }

    [RelayCommand]
    private async Task ReturnItemsTappedAsync()
    {
        await navigationService.GoToPage(nameof(ReturnItemsView));
    }

    [RelayCommand]
    private async Task OnTrackBoxTappedAsync()
    {
        await navigationService.GoToPage(nameof(TrackBoxMenuView));
    }

    [RelayCommand]
    private async Task LogoutTappedAsync()
    {
        Application.Current?.Quit();
    }
}