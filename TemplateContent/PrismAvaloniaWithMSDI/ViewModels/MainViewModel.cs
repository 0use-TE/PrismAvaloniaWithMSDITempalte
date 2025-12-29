using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls.Notifications;
using Avalonia.Styling;
using GameDevTools.Services;
using Prism.Commands;
using Prism.Navigation.Regions;

namespace PrismAvaloniaWithMSDI.ViewModels
{
    internal class MainViewModel:ViewModelBase
    {

     private readonly IRegionManager _regionManager;
        public DelegateCommand<string> ContentRegionNavigation { get; set; }
        public DelegateCommand SwitchThemeCommand { get; set; }

        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            ContentRegionNavigation = new DelegateCommand<string>((regionName)=>
            {
                _regionManager.RequestNavigate("MainContent",regionName);
            });

            SwitchThemeCommand = new DelegateCommand(() =>
            {
                if (App.Current == null) return;

                var currentActual = App.Current.ActualThemeVariant;
                if (currentActual == ThemeVariant.Dark)
                    App.Current.RequestedThemeVariant = ThemeVariant.Light;
                else
                    App.Current.RequestedThemeVariant = ThemeVariant.Dark;
            });
        }
    }
}
