using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpgrades : MonoBehaviour
{
    public TMP_Text CoinAmount;
    public TMP_Text TotalAmount;
    public TMP_Text NotEnoughText;

    public Transform ResupplyPos;
    public GameObject Resupply;

    protected int BuyAmount = 0;
    public int Cost = 20;

    protected int MaxHealthInput = 5;
    protected int MaxArmorInput = 5;
    protected int MaxBombInput = 5;

    protected int HealthCount = 0;
    protected int ArmorCount = 0;
    protected int BombCount = 0;

    public Image[] HealthUpgrades;
    public Image[] ArmorUpgrades;
    public Image[] BombUpgrades;

    private ShopUI _shopUI;
    private Health _health;
    private Armor _armor;
    private ThrowBombs _bomb;
    private ScoreManager _scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        if (NotEnoughText != null)
        {
            NotEnoughText.gameObject.SetActive(false);
        }

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
        _shopUI = GameObject.Find("Shop").GetComponentInChildren<ShopUI>();
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _armor = GameObject.FindGameObjectWithTag("Player").GetComponent<Armor>();
        _bomb = GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowBombs>();
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TotalAmount != null)
        {
            TotalAmount.text = BuyAmount.ToString();
        }
        for (int i = 0; i < _shopUI.HealthInput; i++)
        {
            HealthUpgrades[i].enabled = true;
        }
        for (int i = 0; i < _shopUI.ArmorInput; i++)
        {
            ArmorUpgrades[i].enabled = true;
        }
        for (int i = 0; i < _shopUI.BombInput; i++)
        {
            BombUpgrades[i].enabled = true;
        }
    }
    public void AddHealth()
    {
        if (_shopUI.HealthInput == MaxHealthInput) return;
        if (BuyAmount >= _scoreManager.CoinAmount)
        {
            StartCoroutine(ShowNotEnough());
            return;
        }
        _shopUI.HealthInput += 1;
        BuyAmount += Cost;
        HealthCount += 1;

    }
    public void AddArmor()
    {
        if (_shopUI.ArmorInput == MaxArmorInput) return;
        if (BuyAmount >= _scoreManager.CoinAmount)
        {
            StartCoroutine(ShowNotEnough());
            return;
        }
        _shopUI.ArmorInput += 1;
        BuyAmount += Cost;
        ArmorCount += 1;

    }
    public void AddBomb()
    {
        if (_shopUI.BombInput == MaxBombInput) return;
        if (BuyAmount >= _scoreManager.CoinAmount)
        {
            StartCoroutine(ShowNotEnough());
            return;
        }
        _shopUI.BombInput += 1;
        BuyAmount += Cost;
        BombCount += 1;

    }
    public void Buy()
    {
        if (BuyAmount == 0) return;
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
            if(i%2 == 0)
            {
                _bomb.DamageUpgrade();
            }
            else if (i%2 == 1)
            {
                _bomb.CooldownUpgrade();
            }
        }
        BombCount = 0;
        if(Resupply != null)
            GameObject.Instantiate(Resupply, ResupplyPos.position, ResupplyPos.rotation);
    }
    public IEnumerator ShowNotEnough()
    {
        NotEnoughText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        NotEnoughText.gameObject.SetActive(false);
    }
}
