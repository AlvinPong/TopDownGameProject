using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    SoundManager soundManager;

    protected void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();

        if (soundManager == null)
            Debug.LogWarning("Missing sound mananger, please add it.");
    }

    public void HoverSoundON()
    {
        if (soundManager == null) 
            return;

        soundManager.Play("UI Hover on");
    }

    public void ClickSound()
    {
        if (soundManager == null) 
            return;

        soundManager.Play("UI press");
    }
    public void HoverSoundOff()
    {
        if (soundManager == null) 
            return;

        soundManager.Play("UI hover off");
    }
    public void LowHealth()
    {
        if (soundManager == null)
        {
            return;
        }

        soundManager.Play("Low health");
    }   
    public void ShootingSound()
    {
        if(soundManager == null)
        {
            return;
        }
        soundManager.Play("Firing Sound");
    }
}
