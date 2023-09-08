using Avalonia;
using Avalonia.Controls;
using AvaloniaDemo.Views;

namespace AvaloniaDemo;

public class MainWindow : Window
{
    public MainWindow()
    {
        this.Content = new MainView();

#if DEBUG
        this.AttachDevTools();
#endif
    }
}