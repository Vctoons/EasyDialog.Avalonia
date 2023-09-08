using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using EasyDialog.Avalonia.Dialogs;

namespace AvaloniaDemo.Views;

public partial class MainView : UserControl
{

    public MainView()
    {
        InitializeComponent();

        this.UseEasyDialog()
            .UseEasyLoading();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        using var res = EasyDialogExtensions.DialogService.ShowLoading();

        await Task.Delay(1000);
    }

    private async void Button_OnClick1(object? sender, RoutedEventArgs e)
    {
        var res = await EasyDialogExtensions.DialogService.ShowAsync(new TextBlock()
        {
            Text = "123"
        }, options: opt => { opt.CloseOnClickAway = true; });
    }


    private async void Button_OnClick2(object? sender, RoutedEventArgs e)
    {
        var res = await EasyDialogExtensions.DialogService.ShowConfirmAsync(options: opt =>
        {
            opt.CloseOnClickAway = true;
        });
    }
}