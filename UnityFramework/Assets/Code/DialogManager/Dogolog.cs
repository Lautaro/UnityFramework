using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Dogolog : MonoBehaviour
{


    public List<Button> Buttons;
    public Text TextHolder;
    public Text TitleHolder;

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

        foreach (Button button in Buttons)
        {
            button.gameObject.SetActive(false);
            button.onClick.RemoveAllListeners();
         }

        foreach (DogologOption option in CurrentDog.DogologOptions)
        {
            var button = Buttons.Find(b => b.name == option.ButtonId);
            if (button == null && !string.IsNullOrEmpty( option.ButtonId ))
            {
                Debug.Log("WARNING! A DogologOptions button id is not found among available buttons. Button looked for: " + option.ButtonId );

            }
            else
            {
                SetupButton(button, option.Dog,option.ButtonLabel, option.Message);
            }
        }

        TextHolder.text = CurrentDog.Text;
        TitleHolder.text = CurrentDog.Title;

    }

    private void SetupButton(Button button, Dog dogLink,string buttonLabel, string message)
    {
        if (button == null)
        {
            return;
        }
        button.gameObject.SetActive(true);
        button.GetComponentInChildren<Text>().text = buttonLabel;
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
