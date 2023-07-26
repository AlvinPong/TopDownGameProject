using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHandler : MonoBehaviour
{
    public MeleeWeapon CurrentWeapon;
    public Transform RightWeaponPos;
    public Transform LeftWeaponPos;

    protected bool _tryAttack = false;

    protected Movement _movement;
    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
        if (CurrentWeapon == null)
            return;
        CurrentWeapon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
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
            _tryAttack = true;
        if (Input.GetButtonUp("Fire1"))
            _tryAttack = false;

        if (_tryAttack)
        {
            CurrentWeapon.HandleAttack();
        }
    }
    protected virtual void HandleWeapon()
    {
        //if (CurrentWeapon == null)
        //    return;
        //bool isFlip = false;

        //if (_movement != null && _movement.FlipAnim)
        //{
        //    isFlip = true;
        //}

        //if (isFlip)
        //{
        //    CurrentWeapon.transform.position = LeftWeaponPos.position;
        //    CurrentWeapon.transform.localScale = new Vector3(-1, 1, 1);
        //    CurrentWeapon._isFlip = isFlip;
        //}
        //else
        //{
        //    CurrentWeapon.transform.position = RightWeaponPos.position;
        //    CurrentWeapon.transform.localScale = Vector3.one;
        //    CurrentWeapon._isFlip = isFlip;
        //}
        if (CurrentWeapon == null)
            return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        bool isFlip = (mousePos.x > transform.position.x) ? false : true;

        Vector2 weaponPos = isFlip ? LeftWeaponPos.position : RightWeaponPos.position;
        Vector2 direction = isFlip ? weaponPos - mousePos : mousePos - weaponPos;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        CurrentWeapon.transform.position = weaponPos;
        CurrentWeapon.transform.localScale = isFlip ? new Vector3(-1, 1, 1) : Vector3.one;
        CurrentWeapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        CurrentWeapon.IsFlip = isFlip;

        _movement.FlipAnim = isFlip;
    }
    protected void SwitchWeapon()
    {
        if (Input.GetKeyUp(KeyCode.Alpha2))
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
        if (Input.GetKeyUp(KeyCode.Alpha1))
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
