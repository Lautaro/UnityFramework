using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Dogolog : MonoBehaviour
{

    public Button LeftButton;
    public Button RightButton;
    public Text Text;
    public Text Title;

    public Dog StartDog;
    UnityEvent LeftButtonClick;
    UnityEvent RightButtonClick;

    [SerializeField]
    public UnityStringEvent OnDogologMessage;

    [SerializeField]
    Dog CurrentDog;
    
    void Start()
    {
        if (StartDog == null)
        {
            CloseDogolog();
        }

        CurrentDog = StartDog;
        UpdateDogolog();
    }

    void UpdateDogolog()
    {
        if (CurrentDog == null)
        {
            CloseDogolog();
        }

        Text.text = CurrentDog.Text;
        Title.text = CurrentDog.Title;
        RightButton.GetComponentInChildren<Text>().text = CurrentDog.RightButtonLabel;
        LeftButton.GetComponentInChildren<Text>().text = CurrentDog.LeftButtonLabel;

        RightButton.onClick.RemoveAllListeners();
        LeftButton.onClick.RemoveAllListeners();

        SetupButton(LeftButton, CurrentDog.LeftButtonLink,CurrentDog.LeftButtonMessage);
        SetupButton(RightButton, CurrentDog.RightButtonLink, CurrentDog.RightButtonMessage);

    }

    private void SetupButton(Button button, Dog dogLink, string message)
    {
        button.onClick.AddListener(delegate ()
        {
            ButtonPressed(message, dogLink);
        });
    }

    void ButtonPressed(string message, Dog nextDog)
    {
        if (!string.IsNullOrEmpty(message))
        {
            OnDogologMessage.Invoke(message);
        }

        if (nextDog == null)
        {
            CloseDogolog();
        }
        else
        {
            ChangeDog(nextDog);
        }
    }

    void ChangeDog(Dog nextDog)
    {
        if (nextDog != null)
        {
            CurrentDog = nextDog;
            UpdateDogolog();
        }
    }

    void CloseDogolog()
    {
        gameObject.SetActive(false);
    }

    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string>
    {
    }
}
