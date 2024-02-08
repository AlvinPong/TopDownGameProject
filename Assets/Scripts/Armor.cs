using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public float CurrentArmor = 10f;
    public float MaxArmor = 0f;

    private PlaySound _playsound;
    private ArmorBarUI _armorBar;

    // Start is called before the first frame update
    void Start()
    {
        
        _armorBar = GameObject.Find("ArmorBarUI").GetComponent<ArmorBarUI>();
        _playsound = GetComponent<PlaySound>();
    }

    // Update is called once per frame
    void Update()
    {
        ArmorBreaking();
        if (_armorBar != null)
        {
            _armorBar.SetArmor(CurrentArmor / 10);
        }
    }
    public void ArmorLoss(float value)
    {
        if (CurrentArmor <= 0) return;
        CurrentArmor -= value;
        if (_armorBar != null)
        {
            _armorBar.SetArmor(CurrentArmor / 10);
        }
    }

    public void ArmorBreaking()
    {
        if (CurrentArmor >0)
        {
            _playsound.canShieldsound = true;
        } else if (CurrentArmor <=0)
        {
            _playsound.ShieldBreaking();
            _playsound.canShieldsound = false;
        }
    }
}
