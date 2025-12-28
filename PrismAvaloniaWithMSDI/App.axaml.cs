using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using DryIoc.Microsoft.DependencyInjection;
using GameDevTools.Services;
using Microsoft.Extensions.DependencyInjection;
using Prism.Container.DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation.Regions;
using PrismAvaloniaWithMSDI.ViewModels;
using PrismAvaloniaWithMSDI.Views;
using Serilog;

namespace PrismAvaloniaWithMSDI
{
    public partial class App : PrismApplication
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            // Required when overriding Initialize
            base.Initialize();
        }

        protected override AvaloniaObject CreateShell()
        {
            // 如果是桌面端，返回 MainWindow
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
            {
                return Container.Resolve<MainWindow>();
            }

            // 如果是 WASM 或移动端，返回 MainView (UserControl)
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Debug()
                .CreateLogger();

            var serviceColllection = new ServiceCollection();
            serviceColllection.AddSingleton<INotificationService, NotificationService>();
            //Logging
            serviceColllection.AddLogging(builder =>
            {
                builder.AddSerilog(dispose: true);
            });

            //Pupulate ServiceCollection To DryIoc
            containerRegistry.GetContainer().Populate(serviceColllection);

            // Register you Services, Views, Dialogs, etc.
            containerRegistry.RegisterForNavigation<IndexView>();
            containerRegistry.RegisterForNavigation<OuseView>();

        }
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (ApplicationLifetime is ISingleViewApplicationLifetime single)
                {
                    var topLevel = TopLevel.GetTopLevel(single.MainView);
                    Container.Resolve<INotificationService>().SetHostWindow(topLevel!);

                    //Init navigation
                    //we use requestNavigate instead of RegisterViewWithRegion,because may be we should do something in the callback of OnNavigateTo,
                    //if you use RegisterViewWithRegion,this callback will not be called.
                    var regisionManager = Container.Resolve<IRegionManager>();
                    regisionManager.RequestNavigate("MainContent", nameof(IndexView));
                }
            }, DispatcherPriority.Background);

        }
    }
}
