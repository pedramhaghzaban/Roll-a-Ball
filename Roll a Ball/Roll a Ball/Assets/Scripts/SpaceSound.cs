using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSound : MonoBehaviour {
    public AudioClip mySound;
    public AudioSource spaceSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)){
            spaceSound.clip=mySound;
        }
	}
}
