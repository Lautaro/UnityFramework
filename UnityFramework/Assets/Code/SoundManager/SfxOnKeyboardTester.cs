using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundManager;

public class SfxOnKeyboardTester : MonoBehaviour {

    public float pitch;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            gameObject.PlaySFX("Swirl");
            //  SoundMnager.PlaySFX("Swirl", pitch);
            // GetComponent<AudioSource>().Play();            
        }
        
    }
}
