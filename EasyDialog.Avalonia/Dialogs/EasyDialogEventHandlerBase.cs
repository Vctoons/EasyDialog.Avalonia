using DialogHostAvalonia;

namespace EasyDialog.Avalonia.Dialogs;

public class EasyDialogEventHandlerBase
{
    public DialogOpenedEventHandler? openedHandler { get; set; }
    public DialogClosingEventHandler? closingHandler { get; set; }

    public bool CloseOnClickAway { get; set; }
}

public class ConfirmDialogEventHandler : EasyDialogEventHandlerBase
{
    public string? Title { get; set; }
    public string? Message { get; set; }
    public string? ConfirmBtnText { get; set; }
    public string? CancelBtnText { get; set; }
}