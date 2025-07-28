using CommunityToolkit.Mvvm.Input;
using Scanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.ViewModels
{
    public partial class MoveItemViewModel : ViewModelBase
    {
        public MoveItemViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}