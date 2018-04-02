using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// En UI representation av en stack
/// </summary>
public class InventorySlot : ItemContainer {

     Image Icon;
     Text AmountText;
    public int Amount;
    
    //public Stack 

	// Use this for initialization
	void Start () {

        //Icon = transform.Find("Icon").GetComponent<Image>();
        //AmountText = transform.Find("Amount").GetComponentInChildren<Text>();
        //AmountText.text = Stack.Amount.ToString();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Space");
            Stack = new RedMineral();
        }

        if (Stack != null)
        {
           // Icon.gameObject.SetActive(false);
            Icon.sprite = Resources.Load<Sprite>(Stack.GetIconSpriteFilePath());
            

            Amount = Stack.Amount;
        }
	}
}
