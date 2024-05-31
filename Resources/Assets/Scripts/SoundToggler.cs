using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggler : MonoBehaviour
{
    public static bool isOn;
    private AudioListener audioListener;

    private void Start()
    {
        isOn = true;
        audioListener = GameObject.FindObjectOfType<AudioListener>();
    }

    public void ToggleSound()
    {
        if (isOn)
        {
            AudioListener.volume = 1f;
            isOn = true;
        } 
        else
        {
            AudioListener.volume = 0f;
            isOn = false;
        }
    }
}
