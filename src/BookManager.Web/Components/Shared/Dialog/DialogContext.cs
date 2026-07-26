namespace BookManager.Web.Components.Shared.Dialog;

public class DialogContext
{
    public bool IsOpen { get; set; }

    public Action? StateChanged { get; set; }

    internal Func<bool, Task>? OnOpenChanged { get; set; }

    private void Notify() => StateChanged?.Invoke();

    public async Task OpenAsync()
    {
        IsOpen = true;

        if (OnOpenChanged is not null)
        {
            await OnOpenChanged.Invoke(true);
        }

        Notify();
    }

    public async Task CloseAsync()
    {
        IsOpen = false;

        if (OnOpenChanged is not null)
        {
            await OnOpenChanged.Invoke(false);
        }

        Notify();
    }

    public async Task ToggleAsync()
    {
        if (IsOpen)
        {
            await CloseAsync();
        }
        else
        {
            await OpenAsync();
        }
    }

    internal void SetOpen(bool isOpen)
    {
        IsOpen = isOpen;
        Notify();
    }
}