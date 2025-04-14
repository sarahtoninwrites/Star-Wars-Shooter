using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;
    public AudioSource loopSource;
    public Button muteButton, unmuteButton;
    


void Start(){
    instance = this;
    loopSource.Play();
}

public void Mute(){
    if(instance != null){
        Debug.Log("mute");
    instance.loopSource.mute = true;
    muteButton.gameObject.SetActive(false);
    unmuteButton.gameObject.SetActive(true);

    }
    }

public void Unmute(){
    if(instance != null){
    Debug.Log("unmute");

    instance.loopSource.mute = false;
    unmuteButton.gameObject.SetActive(false);
    muteButton.gameObject.SetActive(true);
    }
}
    
    }

