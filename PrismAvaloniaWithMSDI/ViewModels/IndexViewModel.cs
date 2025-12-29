using System;
using System.Collections.Generic;
using System.Text;
using GameDevTools.Services;
using Prism.Commands;
using Prism.Dialogs;
using Prism.Navigation.Regions;

namespace PrismAvaloniaWithMSDI.ViewModels
{
    internal class IndexViewModel:ViewModelBase,IRegionAware
    {
        public DelegateCommand PopupNotificationCommand { get; set; }
        public AsyncDelegateCommand OpenWindowCommand { get; set; }
        private readonly INotificationService _notificationService;
        private readonly IDialogService _dialogService;
        public IndexViewModel(INotificationService notificationService,IDialogService dialogService)
        {
            _notificationService = notificationService;
            _dialogService = dialogService;
            PopupNotificationCommand = new DelegateCommand(() =>
            {
                _notificationService.ShowSuccess("Welcome", "I am ouse!");
            });
            OpenWindowCommand = new AsyncDelegateCommand(async() =>
            {
                await _dialogService.ShowDialogAsync("CustomWindowView");
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
