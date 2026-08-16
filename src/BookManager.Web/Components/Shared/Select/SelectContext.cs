namespace BookManager.Web.Components.Shared.Select;

public class Item
{
    public string Value { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
}

public class SelectContext
{
    public bool IsOpen { get; private set; }
    public Item? SelectedValue { get; private set; }
    internal Func<Item?, Task>? OnValueChanged { get; set; }
    public Action? StateChanged { get; set; }
    public void Notify() => StateChanged?.Invoke();


    public void SyncValue(Item? value)
    {
        if (Equals(SelectedValue, value)) return;

        SelectedValue = value;

        Notify();
    }

    public async Task SelectAsync(Item? value)
    {
        SelectedValue = value;

        if (OnValueChanged is not null)
        {
            await OnValueChanged.Invoke(value);
        }

        IsOpen = false;

        Notify();
    }

    public void Toggle()
    {
        IsOpen = !IsOpen;

        Notify();
    }

    public void Close()
    {
        IsOpen = false;

        Notify();
    }

    public void Open()
    {
        IsOpen = true;

        Notify();
    }
}