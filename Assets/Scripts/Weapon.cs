using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public Transform SpawnPos;

    public Transform SpawnPos1;
    public Transform SpawnPos2;

    public Cooldown ShootInterval;

    public GameObject[] BulletType;
    public int BulletIndex = 0;

    public bool IsFlip
    {
        set { _isFlip = value; }
    }

    public bool _isFlip = false;
    
    // Update is called once per frame
    void Update()
    {
        if (ShootInterval.CurrentProgress != Cooldown.Progress.Finished)
            return;
        ShootInterval.CurrentProgress = Cooldown.Progress.Ready;
        IntervalUpgrade();
    }
    public void Shoot()
    {
        if (ShootInterval.CurrentProgress != Cooldown.Progress.Ready)
            return;

        //GameObject bullet = GameObject.Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation);
        
        GameObject bullet = GameObject.Instantiate(BulletType[BulletIndex], SpawnPos.position, SpawnPos.rotation);

        if (_isFlip)
        {
            bullet.GetComponent<Projectile>().Speed *= -1;
            bullet.transform.localScale = new Vector3(-1, 1, 1);
        }

        ShootInterval.StartCooldown();
    }
    public void DoubleShoot()
    {
        if (ShootInterval.CurrentProgress != Cooldown.Progress.Ready) return;

        GameObject bullet = GameObject.Instantiate(BulletType[BulletIndex], SpawnPos.position, SpawnPos.rotation);
        GameObject bullet1 = GameObject.Instantiate(BulletType[BulletIndex], SpawnPos1.position, SpawnPos1.rotation);
        GameObject bullet2 = GameObject.Instantiate(BulletType[BulletIndex], SpawnPos2.position, SpawnPos2.rotation);

        if (_isFlip)
        {
            bullet.GetComponent<Projectile>().Speed *= -1;
            bullet1.GetComponent<Projectile>().Speed *= -1;
            bullet2.GetComponent<Projectile>().Speed *= -1;
        }
        

        ShootInterval.StartCooldown();

    }
    public void BulletUpgrade()
    {
        if (BulletType[BulletIndex + 1] == null) return;
        BulletIndex += 1;
    }
    public virtual void IntervalUpgrade()
    {
        if(BulletIndex == 0 || BulletIndex == 1)
        {
            ShootInterval.Duration = 0.3f;
        }
        if(BulletIndex == 2 || BulletIndex == 3)
        {
            ShootInterval.Duration = 0.15f;
        }
        if(BulletIndex == 4)
        {
            ShootInterval.Duration = 0.075f;
        }
    }
}
