using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrader : MonoBehaviour
{
    private Weapon _weapon;
    private WeaponHandler _playerWeapon;

    public bool UseForBullet = false;
    public bool UseForWeapon = false;

    public GameObject Particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(UseForBullet)
        {
            if (!col.gameObject.CompareTag("Player")) return;
            _weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
            _weapon.BulletUpgrade();
            if(Particle != null)
            {
                Instantiate(Particle, transform.position, Quaternion.identity);
            }
            Vanish();
        }
        if(UseForWeapon)
        {
            if (!col.gameObject.CompareTag("Player")) return;
            _playerWeapon = col.GetComponent<WeaponHandler>();
            _playerWeapon.UpgradeInt = 1;
            if (Particle != null)
            {
                Instantiate(Particle, transform.position, Quaternion.identity);
            }
            Vanish();
        }
    }
    private void Vanish()
    {
        Destroy(this.gameObject);
    }
}
