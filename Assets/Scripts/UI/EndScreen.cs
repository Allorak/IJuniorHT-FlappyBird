using System;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;
    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }

    public override void Open()
    {
        ActionButton.interactable = true;
        WindowGroup.alpha = 1f;
    }

    public override void Close()
    {
        ActionButton.interactable = false;
        WindowGroup.alpha = 0f;
    }
}
