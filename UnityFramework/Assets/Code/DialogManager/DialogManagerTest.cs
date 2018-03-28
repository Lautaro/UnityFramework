using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogManagerTest : MonoBehaviour {

    public Dog Dog;
    public UnityEvent WhenFinished;
    

    [SerializeField]
    public Dictionary<string, UnityAction> MyDic = new Dictionary<string, UnityAction>();
	
	// Update is called once per frame
	void Update () {
		
	}
}
