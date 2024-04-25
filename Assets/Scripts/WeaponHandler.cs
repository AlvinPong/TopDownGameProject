using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{

    public Weapon CurrentWeapon;
    public Transform RightWeaponPosition;
    public Transform LeftWeaponPosition;
    public Transform FirePoint;

    protected bool _tryShoot = false;
   
    protected Movement _movement;

    public bool Upgraded = false;
        // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
        if (CurrentWeapon == null)
            return;        
    }

    // Update is called once per frame
    protected virtual void  Update()
    {        
        HandleInput();
        HandleWeapon();
        //ChangeDirection();
    }

    protected virtual void HandleInput()
    {
        if (CurrentWeapon == null) return;
        
        if (Input.GetButtonDown("Fire1"))
            _tryShoot = true;
        if (Input.GetButtonUp("Fire1"))
            _tryShoot = false;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (_tryShoot)
        //    {
        //        _tryShoot = false;
        //        return;
        //    }
        //    if (!_tryShoot)
        //    {
        //        _tryShoot = true;
        //        return;
        //    }
        //}
    }

    protected virtual void HandleWeapon()
    {
        if (CurrentWeapon == null)
            return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        bool isFlip = (mousePos.x > transform.position.x) ? false : true;

        Vector2 gunPos = isFlip ? LeftWeaponPosition.position : RightWeaponPosition.position;
        Vector2 direction = isFlip ? gunPos - mousePos : mousePos - gunPos;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        CurrentWeapon.transform.position = gunPos;
        CurrentWeapon.transform.localScale = isFlip ? new Vector3(-1, 1, 1) : Vector3.one;
        CurrentWeapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        CurrentWeapon.IsFlip = isFlip;

        _movement.FlipAnim = isFlip;

        if (_movement.IsFacingUp)
        {
            CurrentWeapon.GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
        } else
        {
            CurrentWeapon.GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
        }

            if (_tryShoot && Upgraded == false)
            CurrentWeapon.Shoot();
        if (_tryShoot && Upgraded == true)
            CurrentWeapon.DoubleShoot();
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (weapon != null )
            CurrentWeapon = weapon;

    }

    protected virtual void ChangeDirection()
    {
        if (CurrentWeapon == null) return;

        CurrentWeapon.transform.position = FirePoint.position;
        //CurrentWeapon.GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;

        if (_movement.IsFacingUp)
        {
            CurrentWeapon.GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
            CurrentWeapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
            CurrentWeapon.transform.localScale = Vector3.one;
            CurrentWeapon.IsFlip = true;          
        }
        if (_movement.IsFacingDown)
        {
            CurrentWeapon.GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
            CurrentWeapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            CurrentWeapon.transform.localScale = Vector3.one;
            CurrentWeapon.IsFlip = true;
        }
        if (_movement.IsFacingSide && _movement.FlipAnim) //facing left
        {
            CurrentWeapon.GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
            CurrentWeapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            CurrentWeapon.transform.localScale = Vector3.one;
            CurrentWeapon.IsFlip = true;
        }
        if (_movement.IsFacingSide && !_movement.FlipAnim) //facing right
        {
            CurrentWeapon.GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
            CurrentWeapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            CurrentWeapon.transform.localScale = new Vector3(-1, 1, 1);
            CurrentWeapon.IsFlip = false;
        }
        if (_tryShoot && Upgraded == false)
            CurrentWeapon.Shoot();
        if(_tryShoot && Upgraded == true)
            CurrentWeapon.DoubleShoot();
    }
}
