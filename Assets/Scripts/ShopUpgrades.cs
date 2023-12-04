using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpgrades : MonoBehaviour
{
    public TMP_Text CoinAmount;
    public TMP_Text TotalAmount;
    public TMP_Text NotEnough;

    protected int BuyAmount = 0;
    public int Cost = 20;

    protected int MaxHealthInput = 5;
    protected int MaxArmorInput = 5;
    protected int MaxBombInput = 5;

    protected int HealthInput = 0;
    protected int ArmorInput = 0;
    protected int BombInput = 0;

    protected int HealthCount = 0;
    protected int ArmorCount = 0;
    protected int BombCount = 0;

    public Image[] HealthUpgrades;
    public Image[] ArmorUpgrades;
    public Image[] BombUpgrades;

    private Health _health;
    private Armor _armor;
    private ThrowBombs _bomb;
    private ScoreManager _scoreManager;

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

        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _armor = GameObject.FindGameObjectWithTag("Player").GetComponent<Armor>();
        _bomb = GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowBombs>();
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TotalAmount.text = BuyAmount.ToString();
    }
    public void AddHealth()
    {
        if (HealthInput == MaxHealthInput) return;
        if (BuyAmount > _scoreManager.CoinAmount) return;
        HealthInput += 1;
        BuyAmount += Cost;
        HealthCount += 1;

        for (int i = 0; i < HealthInput; i++)
        {
            HealthUpgrades[i].enabled = true;
        }

        //_health.MaxHealth += 1;
    }
    public void AddArmor()
    {
        if (ArmorInput == MaxArmorInput) return;
        if (BuyAmount > _scoreManager.CoinAmount) return;
        ArmorInput += 1;
        BuyAmount += Cost;
        ArmorCount += 1;

        for (int i = 0; i < ArmorInput; i++)
        {
            ArmorUpgrades[i].enabled = true;
        }

        //_armor.MaxArmor += 2;
    }
    public void AddBomb()
    {
        if (BombInput == MaxBombInput) return;
        if (BuyAmount > _scoreManager.CoinAmount) return;
        BombInput += 1;
        BuyAmount += Cost;
        BombCount += 1;

        for (int i = 0; i < BombInput; i++)
        {
            BombUpgrades[i].enabled = true;
        }

        //_bomb.Amount += 1;
    }
    public void Buy()
    {
        _scoreManager.CoinAmount -= BuyAmount;
        BuyAmount = 0;

        for (int i = HealthCount; i > 0; i--)
        {
            _health.MaxHealth += 1;
        }
        HealthCount = 0;

        for (int i = ArmorCount; i > 0; i--)
        {
            _armor.MaxArmor += 2;
        }
        ArmorCount = 0;

        for (int i = BombCount; i > 0; i--)
        {
            _bomb.MaxAmount += 1;
        }
        BombCount = 0;
    }
}
