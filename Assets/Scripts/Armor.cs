using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public float CurrentArmor = 10f;

    private ArmorBarUI _armorBar;
    // Start is called before the first frame update
    void Start()
    {
        _armorBar = GameObject.Find("ArmorBarUI").GetComponent<ArmorBarUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
