using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    public PlaySound _playsound;

    private void Start()
    {
        _playsound.GetComponent<PlaySound>();

        WarningSound();
    }


    public void WarningSound()
    {
        if (_playsound == null)
            return;

        _playsound.WarningSound();

    }
}
