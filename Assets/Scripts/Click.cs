// Play click sound effect when a key is pressed.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public AudioClip clickclip;

    void Start() {
      GetComponent<AudioSource>().clip = clickclip;  
    }

    void Update() {
        if(Input.anyKeyDown) {
            GetComponent<AudioSource>().Play();
        }
    }
}
