using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpgrades : MonoBehaviour
{
    public TMP_Text CoinAmount;
    public TMP_Text TotalAmount;

    protected float BuyAmount;
    public float Cost = 20;

    public Image[] BarHealth; 

    protected int MaxHealthInput = 5;
    protected int MaxArmorInput = 5;
    protected int MaxBombInput = 5;

    protected int HealthInput = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalAmount.text = BuyAmount.ToString();
    }
    public void AddHealth()
    {
        if (HealthInput == MaxHealthInput) return;
        HealthInput += 1;
        BuyAmount += Cost;
        
    }
    public void AddArmor()
    {
        BuyAmount += Cost;
    }
    public void AddBomb()
    {
        BuyAmount += Cost;
    }
    public void Buy()
    {

    }
}
