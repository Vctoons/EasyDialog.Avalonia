using System.Diagnostics.CodeAnalysis;

namespace EasyDialog.Avalonia.Dialogs;

internal class DisposeAction : IDisposable
{
    private readonly Action _action;

    public DisposeAction([NotNull] Action action)
    {
        this._action = action;
    }

    public void Dispose() => this._action();
}