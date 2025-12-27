using System;
using System.Collections.Generic;
using System.Text;
using GameDevTools.Services;
using Prism.Commands;
using Prism.Navigation.Regions;

namespace PrismAvaloniaWithMSDI.ViewModels
{
    internal class IndexViewModel:ViewModelBase,IRegionAware
    {
        public DelegateCommand PopupNotificationCommand { get; set; }
        private readonly INotificationService _notificationService;
        public IndexViewModel(INotificationService notificationService)
        {
            _notificationService = notificationService;
            PopupNotificationCommand = new DelegateCommand(() =>
            {
                _notificationService.ShowSuccess("Welcome", "I am ouse!");
            });
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //Handle some logic like load data.
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
