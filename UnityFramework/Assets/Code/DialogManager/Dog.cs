using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Dog", fileName ="New Dog")]
public class Dog : ScriptableObject
{    
    public string Title;
    public string Text;
    public Dog LeftButtonLink;
    public string LeftButtonLabel;
    public string LeftButtonMessage;
  
    public Dog RightButtonLink;
    public string RightButtonLabel;
    public string RightButtonMessage;
 

}
