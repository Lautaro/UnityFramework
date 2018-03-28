using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Dogolog : MonoBehaviour {

    public Button LeftButton;
    public Button RightButton;
    public Text Text;
    public Text Title;
  
    public Dog StartDog;
    UnityEvent LeftButtonClick;
    UnityEvent RightButtonClick;

    [SerializeField]
    Dog CurrentDog;
  

    // Use this for initialization
    void Start ()
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
        
    }

    private void CloseDogolog()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}



}
