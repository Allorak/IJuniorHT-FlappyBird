 using System;
 using UnityEngine;

 public class StartScreen : Window
{
    public event Action PlayButtonClicked;
    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }

    public override void Open()
    {
        Debug.Log("Start screen opened");
        ActionButton.interactable = true;
        WindowGroup.alpha = 1f;
    }

    public override void Close()
    {
        Debug.Log("Start screen closed");
        ActionButton.interactable = false;
        WindowGroup.alpha = 0f;
    }
}
