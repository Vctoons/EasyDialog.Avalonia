# EasyDialog.Avalonia

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://mit-license.org/)
[![GitHub Stars](https://img.shields.io/github/stars/Vctoons/EasyDialog.Avalonia.svg)](https://github.com/Vctoons/EasyDialog.Avalonia/stargazers)
[![GitHub Issues](https://img.shields.io/github/issues/Vctoons/EasyDialog.Avalonia.svg)](https://github.com/Vctoons/EasyDialog.Avalonia/issues)

## Introduction

make you easily to use Dialog in Avalonia.

## Nuget Packages

| Name                  | Version                                                                                                                                     | Download                                                                                                                                     |
|-----------------------|---------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------|
| EasyDialog.Avalonia | [![EasyDialog.Avalonia](https://img.shields.io/nuget/v/EasyDialog.Avalonia.svg)](https://www.nuget.org/packages/EasyDialog.Avalonia/) | [![EasyDialog.Avalonia](https://img.shields.io/nuget/dt/EasyDialog.Avalonia.svg)](https://www.nuget.org/packages/EasyDialog.Avalonia/) |

## Avalonia Framework Tests

* Desktop
  * [x] Windows
  * [ ] Mac
  * [ ] Linux
* Mobile
  * [x] Android
  * [ ] iOS
* Web
  * [x] WebAssembly

## Use

1. Add Package Reference `EasyDialog.Avalonia`
2. Add Services, or you can new DialogService on yourself

```csharp
services.AddEasyDialog();
```

3. Use Style in App.xaml

```csharp
xmlns:dialog="clr-namespace:EasyDialog.Avalonia;assembly=EasyDialog.Avalonia"
```

```xml
    <Application.Styles>
        <dialog:EasyDialog/>
    </Application.Styles>
```

4. Inject to you window or view in `App.cs`
you need input you view or window in CreateDialogWindow or 
```csharp

if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
{
    desktop.MainWindow = new MainWindow
    {
        DataContext = new MainViewModel()
    }.CreateDialogWindow();
}
else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
{
    singleViewPlatform.MainView = new MainView
    {
        DataContext = new MainViewModel()
    }.CreateDialogView();
}
```

5. get your `DialogService` to use
```csharp
    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        using var res = dialogService.ShowLoading();

        await Task.Delay(1000);
    }

    private async void Button_OnClick1(object? sender, RoutedEventArgs e)
    {
        var res = await dialogService.ShowAsync(new TextBlock()
        {
            Text = "123"
        }, options: opt => { opt.CloseOnClickAway = true; });
    }

    
    private async void Button_OnClick2(object? sender, RoutedEventArgs e)
    {
        var res = await dialogService.ShowConfirmAsync(options: opt => { opt.CloseOnClickAway = true; });
    }
```

## Extend

### Use in other window or view

also you can to use  `CreateDialogWindow` or `CreateDialogView`,to include in you view ,give a different identifier.

### Extension DialogService

also you can write extensions on `DialogService` to realize your dialog logic


## Credits

[Avalonia](https://github.com/AvaloniaUI/Avalonia)

[Semi.Avalonia](https://github.com/irihitech/Semi.Avalonia)

[DialogHost.Avalonia](https://github.com/AvaloniaUtils/DialogHost.Avalonia)

## License

> You can check out the full license [here](https://github.com/Vctoons/EasyDialog.Avalonia/blob/master/LICENSE)

This project is licensed under the terms of the **MIT** license.
