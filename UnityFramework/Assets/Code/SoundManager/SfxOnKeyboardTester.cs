using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxOnKeyboardTester : MonoBehaviour {

    public float pitch = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.PlaySFX("UI_Success", pitch);
            pitch++;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
  
            pitch=0;
        }
    }
}
