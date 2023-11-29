using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public Transform SpawnPos;
    public Cooldown ShootInterval;
    private PlaySound _playsound;
    public bool IsFlip
    {
        set { _isFlip = value; }
    }

    public bool _isFlip = false;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (ShootInterval.CurrentProgress != Cooldown.Progress.Finished)
            return;
        ShootInterval.CurrentProgress = Cooldown.Progress.Ready;
    }
    public void Shoot()
    {
        if (ShootInterval.CurrentProgress != Cooldown.Progress.Ready)
            return;

        GameObject bullet = GameObject.Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation);
        

        if (_isFlip)
            bullet.GetComponent<Projectile>().Speed *= -1;

        ShootInterval.StartCooldown();
        
    }
    
}
