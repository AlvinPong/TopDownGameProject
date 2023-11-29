using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpgrades : MonoBehaviour
{
    public TMP_Text CoinAmount;
    public TMP_Text TotalAmount;

    protected float CurrentCoin;
    protected float BuyAmount;
    public float Cost = 20;

    protected int MaxHealthInput = 5;
    protected int MaxArmorInput = 5;
    protected int MaxBombInput = 5;

    protected int HealthInput = 0;
    protected int ArmorInput = 0;
    protected int BombInput = 0;

    public Image[] HealthUpgrades;
    public Image[] ArmorUpgrades;
    public Image[] BombUpgrades;

    public TMP_Text NotEnough;

    // Start is called before the first frame update
    void Start()
    {
        NotEnough.gameObject.SetActive(false);

        for (int i = 0; i < HealthUpgrades.Length; i++)
        {
            HealthUpgrades[i].enabled = false ;
        }
        for (int i = 0; i < ArmorUpgrades.Length; i++)
        {
            ArmorUpgrades[i].enabled = false ;
        }
        for (int i = 0; i < BombUpgrades.Length; i++)
        {
            BombUpgrades[i].enabled = false ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TotalAmount.text = BuyAmount.ToString();
    }
    public void AddHealth()
    {
        if (HealthInput == MaxHealthInput) return;
        //if (BuyAmount > CurrentCoin) return;
        HealthInput += 1;
        //BuyAmount += Cost;

        for (int i = 0; i < HealthInput; i++)
        {
            HealthUpgrades[i].enabled = true;
        }

    }
    public void AddArmor()
    {
        if (ArmorInput == MaxArmorInput) return;
        //if (BuyAmount > CurrentCoin) return;
        ArmorInput += 1;
        //BuyAmount += Cost;

        for (int i = 0; i < ArmorInput; i++)
        {
            ArmorUpgrades[i].enabled = true;
        }
    }
    public void AddBomb()
    {
        if (BombInput == MaxBombInput) return;
        //if (BuyAmount > CurrentCoin) return;
        BombInput += 1;
        //BuyAmount += Cost;

        for (int i = 0; i < BombInput; i++)
        {
            BombUpgrades[i].enabled = true;
        }
    }
    public void Buy()
    {

    }
}
