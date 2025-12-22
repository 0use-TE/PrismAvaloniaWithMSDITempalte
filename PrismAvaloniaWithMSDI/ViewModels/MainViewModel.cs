using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls.Notifications;
using GameDevTools.Services;
using Prism.Commands;
using Prism.Navigation.Regions;

namespace PrismAvaloniaWithMSDI.ViewModels
{
    internal class MainViewModel:ViewModelBase
    {
     private readonly IRegionManager _regionManager;
        public DelegateCommand<string> ContentRegionNavigation { get; set; }
        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            ContentRegionNavigation = new DelegateCommand<string>((regionName)=>
            {
                _regionManager.RequestNavigate("MainContent",regionName);
            });
        }
    }
}
