using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaDemo.Consts;
using EasyDialog.Avalonia.Dialogs;

namespace AvaloniaDemo.Views;

public partial class InnerView : UserControl
{
    const string CurrentIdentifier = DialogServiceConsts.InnerViewIdentifier;
    public InnerView()
    {
        InitializeComponent();
        this.UseEasyDialog(CurrentIdentifier).UseEasyLoading(CurrentIdentifier);
    }

    private async void ShowLoading(object? sender, RoutedEventArgs e)
    {
        
        using var res = EasyDialogExtensions.DialogService.ShowLoading(CurrentIdentifier);

        await Task.Delay(1000);
        
    }

    private async void ShowDialog(object? sender, RoutedEventArgs e)
    {
        var res = await EasyDialogExtensions.DialogService.ShowConfirmAsync(CurrentIdentifier,options: opt =>
        {
            opt.CloseOnClickAway = true;
        });
    }
}