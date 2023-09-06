using Avalonia.Controls;
using Avalonia.Interactivity;
using EasyDialog.Avalonia.Dialogs;

namespace EasyDialogDemo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        using var res = DialogExtensions.DialogService.ShowLoading();

        await Task.Delay(1000);
    }

    private async void Button_OnClick1(object? sender, RoutedEventArgs e)
    {
        var res = await DialogExtensions.DialogService.ShowAsync(new TextBlock()
        {
            Text = "123"
        }, options: opt => { opt.CloseOnClickAway = true; });
    }

    
    private async void Button_OnClick2(object? sender, RoutedEventArgs e)
    {
        var res = await DialogExtensions.DialogService.ShowConfirmAsync(options: opt => { opt.CloseOnClickAway = true; });
    }

    
}