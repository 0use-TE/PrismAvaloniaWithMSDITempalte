using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls.Notifications;
using GameDevTools.Services;
using Prism.Commands;

namespace PrismAvaloniaWithMSDI.ViewModels
{
    internal class MainViewModel:ViewModelBase
    {
        public DelegateCommand PopupNotificationCommand { get; set; }
        private readonly INotificationService _notificationService;
        public MainViewModel(INotificationService  notificationService)
        {
            _notificationService = notificationService;
            PopupNotificationCommand = new DelegateCommand(() =>
            {
                _notificationService.ShowSuccess("Welcome", "I am ouse!");
            });
        }
    }
}
