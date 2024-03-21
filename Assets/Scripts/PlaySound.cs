using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    SoundManager soundManager;

    public bool canShieldsound;

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
        soundManager.Play("Firing sound");
    }
    public void ShieldBreaking()
    {
        if (soundManager == null)
        {
            return;
        }

        if (!canShieldsound)
            return;

        soundManager.Play("Shield breaking");
    }
    public void ZombieMoans()
    {
        if (soundManager == null)
        {
            return;
        }

        soundManager.Play("Zombies moan");
    }
    public void PlayerMoan()
    {
        if (soundManager == null)
        {
            return;           
        }

        
        soundManager.Play("Player hurt");
    }
    public void BuySound()
    {
        if (soundManager == null)
        {
            return;
        }


        soundManager.Play("Buy Sound");
    }
    public void HealBuy()
    {
        if (soundManager == null)
        {
            return;
        }


        soundManager.Play("Heal Buy");
    }
    public void ShieldBuy()
    {
        if (soundManager == null)
        {
            return;
        }


        soundManager.Play("Shield Gain");
    }
    public void BombLoad()
    {
        if (soundManager == null)
        {
            return;
        }


        soundManager.Play("Bomb Gain");
    }
    public void PickUp()
    {
        if (soundManager == null)
        {
            return;
        }


        soundManager.Play("Pick Up");
    }
    public void BombBoom()
    {
        if (soundManager == null)
        {
            return;
        }


        soundManager.Play("Bomb Exploding");
    }
    public void MiniBossSound()
    {
        if (soundManager == null)
        {
            return;
        }


        soundManager.Play("MiniBossHurt");
    }

    public void MiniBossRoar()
    {
        if (soundManager == null)
        {
            return;
        }


        soundManager.Play("MiniBossRoar");
    }
    public void BulletLevel1Sound()
    {
        if (soundManager == null)
        {
            return;
        }


        soundManager.Play("BulletProjectileLevel1");
    }
    public void BulletLevel3Sound()
    {
        if (soundManager == null)
        {
            return;
        }


        soundManager.Play("BulletProjectileLevel3");
    }
    public void WarningSound()
    {
        if (soundManager == null)
        {
            return;
        }


        soundManager.Play("Warning sound");
    }
}
