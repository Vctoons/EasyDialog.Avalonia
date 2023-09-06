using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaDemo.ViewModels;
using AvaloniaDemo.Views;
using EasyDialog.Avalonia.Dialogs;

namespace AvaloniaDemo;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = EasyDialogExtensions.CreateDialogWindow(new MainWindow
            {
                DataContext = new MainViewModel()
            });
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = EasyDialogExtensions.CreateDialogView(new MainView
            {
                DataContext = new MainViewModel()
            });
        }

        base.OnFrameworkInitializationCompleted();
    }
}