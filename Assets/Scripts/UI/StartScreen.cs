 using System;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;
    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
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
