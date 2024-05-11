using System;
using UnityEngine;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;
    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }

    public override void Open()
    {
        Debug.Log("End screen opened");
        ActionButton.interactable = true;
        WindowGroup.alpha = 1f;
    }

    public override void Close()
    {
        Debug.Log("End screen closed");
        ActionButton.interactable = false;
        WindowGroup.alpha = 0f;
    }
}
