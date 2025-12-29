using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Dialogs;
using Prism.Navigation.Regions;

namespace PrismAvaloniaWithMSDI.ViewModels
{
    internal class OuseViewModel:ViewModelBase,INavigationAware
    {
        public OuseViewModel()
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}
