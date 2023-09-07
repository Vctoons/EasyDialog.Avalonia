namespace EasyDialog.Avalonia.Dialogs;

internal class ConvertHelper
{
    // 编写类型转换方法 To<>
    public static T To<T>(object value)
    {
        return (T) Convert.ChangeType(value, typeof(T));
    }
}