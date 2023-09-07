using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Media;
using DialogHostAvalonia;
using EasyDialog.Avalonia.Loading;

namespace EasyDialog.Avalonia.Dialogs;

public class DialogService
{
    public event Action<string, Action<EasyDialogLoadingContainer>, bool> OnDialogShowLoadingHandler;

    public async Task<TViewModel?> ShowGetDataContextAsync<TViewModel>(Control view, string? identifier = null,
        Action<EasyDialogEventHandlerBase>? options = null)
        where TViewModel : class
    {
        var handler = new EasyDialogEventHandlerBase();
        options?.Invoke(handler);
        var dialog = await DialogHost.Show(view, identifier ?? DialogConsts.MainViewDefaultIdentifier,
            (s, e) =>
            {
                handler.openedHandler?.Invoke(s, e);
                var host = (e.Source as DialogHost)!;
                host.CloseOnClickAway = handler.CloseOnClickAway;
            },
            handler.closingHandler);

        var res = ((dynamic)dialog!)?.DataContext;
        return res;
    }

    public virtual Task<object?> ShowAsync(Control view, string? identifier = null,
        Action<EasyDialogEventHandlerBase>? options = null)
    {
        var handler = new EasyDialogEventHandlerBase();
        options?.Invoke(handler);
        return ShowAsync(view, identifier, handler);
    }

    protected virtual async Task<object?> ShowAsync(Control view, string? identifier = null,
        EasyDialogEventHandlerBase? handler = null)
    {
        var res = await DialogHost.Show(view, identifier ?? DialogConsts.MainViewDefaultIdentifier,
            (s, e) =>
            {
                handler?.openedHandler?.Invoke(s, e);
                var host = (e.Source as DialogHost)!;
                host.CloseOnClickAway = handler?.CloseOnClickAway ?? false;
            },
            handler?.closingHandler);

        return res;
    }

    public virtual async Task<bool> ShowConfirmAsync(string? identifier = null,
        Action<ConfirmDialogEventHandler>? options = null)
    {
        var handler = new ConfirmDialogEventHandler();

        handler.openedHandler = (sender, args) =>
        {
            var host = (args.Source as DialogHost)!;
            host.CloseOnClickAway = true;
            host.CloseOnClickAwayParameter = false;
        };

        options?.Invoke(handler);

        //
        var binding = new Binding("CloseDialogCommand");
        binding.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor);
        binding.RelativeSource.AncestorType = typeof(DialogHost);
        var cancelBtn = new Button()
        {
            Content = handler.CancelBtnText ?? "Cancel",
        };

        cancelBtn.Bind(Button.CommandProperty, binding);
        cancelBtn.CommandParameter = false;

        var confirmBtn = new Button()
        {
            Content = handler.ConfirmBtnText ?? "Confirm",
        };
        confirmBtn.Bind(Button.CommandProperty, binding);
        confirmBtn.CommandParameter = true;


        var stackPanel = new StackPanel()
        {
            Margin = new Thickness(16),
            Spacing = 20,
            Children =
            {
                new TextBlock()
                {
                    Text = handler.Title ?? "Hint",
                    FontWeight = FontWeight.Bold,
                    FontSize = 22
                },
                new TextBlock()
                {
                    Text = handler.Message ??
                           "Are you sure?",
                    FontSize = 18
                },
                new StackPanel()
                {
                    Spacing = 20,
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Children =
                    {
                        cancelBtn,
                        confirmBtn
                    }
                }
            }
        };
        var res = await ShowAsync(stackPanel, identifier,
            handler);
        return (bool?)res ?? false;
    }

    public virtual IDisposable ShowLoading(string? identifier = null,
        Action<EasyDialogLoadingContainer> loadingOptions = null)
    {
        // TODO: need to Create a new LoadingContainer ?
        OnDialogShowLoadingHandler?.Invoke(identifier ?? DialogConsts.MainViewLoadingIdentifier, loadingOptions, true);

        return new DisposeAction(() =>
        {
            OnDialogShowLoadingHandler?.Invoke(identifier ?? DialogConsts.MainViewLoadingIdentifier, loadingOptions,
                false);
        });
    }
    //
    // public IDisposable ShowContextLoading()
    // {
    //     return ShowLoading(DialogConsts.MainViewContextLoadingIdentifier);
    // }
}