using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace EasyDialog.Avalonia;

public class EasyDialog : Styles
{
    /// <inheritdoc />
    public EasyDialog()
    {
        AvaloniaXamlLoader.Load(this);
    }

    /// <inheritdoc />
    public EasyDialog(IResourceHost owner) : base(owner)
    {
        AvaloniaXamlLoader.Load(this);
    }
}