using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Templates;

namespace EasyDialog.Avalonia.Loading;

[PseudoClasses(PC_Loading)]
public class EasyDialogLoadingContainer : ContentControl
{
    public const string PC_Loading = ":loading";

    public static readonly StyledProperty<object?> IndicatorProperty = AvaloniaProperty.Register<EasyDialogLoadingContainer, object?>(
        nameof(Indicator));

    public object? Indicator
    {
        get => GetValue(IndicatorProperty);
        set => SetValue(IndicatorProperty, value);
    }

    public static readonly StyledProperty<object?> LoadingMessageProperty = AvaloniaProperty.Register<EasyDialogLoadingContainer, object?>(
        nameof(LoadingMessage));

    public object? LoadingMessage
    {
        get => GetValue(LoadingMessageProperty);
        set => SetValue(LoadingMessageProperty, value);
    }

    public static readonly StyledProperty<IDataTemplate> LoadingMessageTemplateProperty = AvaloniaProperty.Register<EasyDialogLoadingContainer, IDataTemplate>(
        nameof(LoadingMessageTemplate));

    public IDataTemplate LoadingMessageTemplate
    {
        get => GetValue(LoadingMessageTemplateProperty);
        set => SetValue(LoadingMessageTemplateProperty, value);
    }

    public static readonly StyledProperty<bool> IsLoadingProperty = AvaloniaProperty.Register<EasyDialogLoadingContainer, bool>(
        nameof(IsLoading));

    public bool IsLoading
    {
        get => GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }

    static EasyDialogLoadingContainer()
    {
        IsLoadingProperty.Changed.AddClassHandler<EasyDialogLoadingContainer>((x, e) => x.OnIsLoadingChanged(e));
    }

    private void OnIsLoadingChanged(AvaloniaPropertyChangedEventArgs args)
    {
        bool newValue = args.GetNewValue<bool>();
        PseudoClasses.Set(PC_Loading, newValue);
    }
}