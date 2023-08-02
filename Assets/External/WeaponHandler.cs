using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{

    public Weapon CurrentWeapon;
    public Transform RightWeaponPosition;
    public Transform LeftWeaponPosition;
    
    protected bool _tryShoot = false;

    //public int Ammo = 12;
    //public int maxAmmo = 120;

    protected Movement _movement;
        // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
        if (CurrentWeapon == null)
            return;
        CurrentWeapon.gameObject.SetActive(true);
    }

    // Update is called once per frame
    protected virtual void  Update()
    {
        SwitchWeapon();
        HandleInput();
        HandleWeapon();
        
    }

    protected virtual void HandleInput()
    {
        if (CurrentWeapon == null) return;
        if (!CurrentWeapon.isActiveAndEnabled)
            return;
        if (Input.GetButtonDown("Fire1"))
            _tryShoot = true;
        if (Input.GetButtonUp("Fire1"))
            _tryShoot = false;

        //reload
        //if (Input.GetKeyUp(KeyCode.R))
        //{
        //    int reload = 0;
        //    for (int i = 0; Ammo <= 12; i++)
        //    {
        //        Ammo += 1;
        //        reload++;
        //    }
        //    maxAmmo = maxAmmo - reload;
        //}
    }
    
    protected virtual void  HandleWeapon()
    {
        if (CurrentWeapon == null)
            return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        bool isFlip = (mousePos.x > transform.position.x) ? false : true;

        Vector2 gunPos =  isFlip ?  LeftWeaponPosition.position : RightWeaponPosition.position;
        Vector2 direction = isFlip ? gunPos - mousePos: mousePos - gunPos;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        CurrentWeapon.transform.position =  gunPos;
        CurrentWeapon.transform.localScale = isFlip ? new Vector3(-1,1,1) : Vector3.one;
        CurrentWeapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        CurrentWeapon.IsFlip = isFlip;

        _movement.FlipAnim = isFlip;
        
        if (_tryShoot)
            CurrentWeapon.Shoot();

        //if (_tryShoot)
        //{
        //    if (Ammo > 0)
        //    {
        //        CurrentWeapon.Shoot();
        //        Ammo--;
        //    }
        //}
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (weapon != null )
            CurrentWeapon = weapon;

    }
    protected void SwitchWeapon()
    {
        // need to switch to arrays for individual weapon
        // need at least array size of 6
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (CurrentWeapon.isActiveAndEnabled)
            {
                return;
            }
            else
            {
                CurrentWeapon.transform.gameObject.SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (CurrentWeapon.isActiveAndEnabled)
            {
                CurrentWeapon.transform.gameObject.SetActive(false);
            }
            else
            {
                return;
            }
        }
    }
}
