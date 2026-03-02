using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Styling;
using GameDevTools.Services;
using Prism.Commands;
using Prism.Navigation.Regions;

namespace PrismAvaloniaWithMSDI.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {

        public DelegateCommand SwitchThemeCommand { get; set; }
        public DelegateCommand ShowNotificationCommand { get; set; }
        public DelegateCommand<Control> SetNotificationHostCommand { get; set; }
        private readonly INotificationService _notificationService;

        public MainViewModel(INotificationService notificationService)
        {

            _notificationService = notificationService;
            SwitchThemeCommand = new DelegateCommand(() =>
            {
                if (App.Current == null) return;

                var currentActual = App.Current.ActualThemeVariant;
                if (currentActual == ThemeVariant.Dark)
                    App.Current.RequestedThemeVariant = ThemeVariant.Light;
                else
                    App.Current.RequestedThemeVariant = ThemeVariant.Dark;
            });

            ShowNotificationCommand = new DelegateCommand(() =>
            {
                _notificationService.ShowSuccess("Hi", "Welcome to avalonia");
            });

            SetNotificationHostCommand = new DelegateCommand<Control>(control =>
            {
                var topLevel = TopLevel.GetTopLevel(control);
                if (topLevel == null)
                {
                    throw new ArgumentNullException(nameof(topLevel));
                }

                _notificationService.SetHostWindow(topLevel);
            });
        }
    }
}
