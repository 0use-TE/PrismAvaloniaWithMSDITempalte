using Avalonia.Styling;
using Prism.Commands;

namespace PrismAvaloniaWithMSDI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            SwitchThemeCommand = new DelegateCommand(() =>
            {
                if (App.Current == null) return;

                var currentActual = App.Current.ActualThemeVariant;
                if (currentActual == ThemeVariant.Dark)
                {
                    App.Current.RequestedThemeVariant = ThemeVariant.Light;
                }
                else
                {
                    App.Current.RequestedThemeVariant = ThemeVariant.Dark;
                }
            });
        }
        public DelegateCommand SwitchThemeCommand { get; set; }

    }
}
