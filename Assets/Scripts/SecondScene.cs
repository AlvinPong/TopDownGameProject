using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SecondScene : MonoBehaviour
{
    public float NewHealth;
    public float NewMaxHealth;
    public float NewArmor;
    public float NewMaxArmor;
    public float NewBombAmount;
    public float NewMaxBomb;

    public string PlayerHealth = "PlayerCurrentHealth";
    public string PlayerMaxHealth = "PlayerMaxHealth";
    public string PlayerArmor = "PlayerCurrentArmor";
    public string PlayerMaxArmor = "PlayerMaxArmor";
    public string PlayerBombs = "PlayerCurrentBombs";
    public string PlayerMaxBombs = "PlayerMaxBombs";

    private Health _playerHealth;
    private Armor _playerArmor;
    private ThrowBombs _playerBombs;

    private ShopUpgrades _shopUpgrades;

    public string HealthUpgrade = "ShopHealthUpgrade";
    public string ArmorUpgrade = "ShopArmorUpgrade";
    public string BombUpgrade = "ShopBombUpgrade";

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _playerArmor = GameObject.FindGameObjectWithTag("Player").GetComponent<Armor>();
        _playerBombs = GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowBombs>();

        NewHealth = PlayerPrefs.GetFloat(PlayerHealth);
        NewMaxHealth = PlayerPrefs.GetFloat(PlayerMaxHealth);
        NewArmor = PlayerPrefs.GetFloat(PlayerArmor);
        NewMaxArmor = PlayerPrefs.GetFloat(PlayerMaxArmor);
        NewBombAmount = PlayerPrefs.GetFloat(PlayerBombs);
        NewMaxBomb = PlayerPrefs.GetFloat(PlayerMaxBombs);

        SetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SavePlayerStats()
    {
        PlayerPrefs.SetFloat(PlayerHealth, _playerHealth._currentHealth);
        PlayerPrefs.SetFloat(PlayerMaxHealth, _playerHealth.MaxHealth);
        PlayerPrefs.SetFloat(PlayerArmor, _playerArmor.CurrentArmor);
        PlayerPrefs.SetFloat(PlayerMaxArmor, _playerArmor.MaxArmor);
        PlayerPrefs.SetFloat(PlayerBombs, _playerBombs.Amount);
        PlayerPrefs.SetFloat(PlayerMaxBombs, _playerBombs.MaxAmount);
    }
    public void SetPlayer()
    {
        _playerHealth._currentHealth = NewHealth;
        _playerHealth.MaxHealth = NewMaxHealth;
        _playerArmor.CurrentArmor = NewArmor;
        _playerArmor.MaxArmor = NewMaxArmor;
        _playerBombs.Amount = NewBombAmount;
        _playerBombs.MaxAmount = NewMaxBomb;
    }
}
