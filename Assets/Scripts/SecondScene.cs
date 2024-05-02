using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SecondScene : MonoBehaviour
{
    public string PlayerHealth = "PlayerCurrentHealth";
    public string PlayerMaxHealth = "PlayerMaxHealth";
    public string PlayerArmor = "PlayerCurrentArmor";
    public string PlayerMaxArmor = "PlayerMaxArmor";
    public string PlayerBombsDamage = "PlayerBombDamage";
    public string PlayerBombsCooldown = "PlayerBombCooldown";

    private Health _playerHealth;
    private Armor _playerArmor;
    private ThrowBombs _playerBombs;

    public string PlayerCoins = "PlayerCurrentCoins";

    public string WeaponUpgraded = "WeaponUpgraded";
    public string BulletUpgrade = "CurrentBullet";

    private WeaponHandler _weaponHandler;
    private Weapon _weapon;
    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _playerArmor = GameObject.FindGameObjectWithTag("Player").GetComponent<Armor>();
        _playerBombs = GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowBombs>();
        _weaponHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponHandler>();
        _weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
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
        PlayerPrefs.SetFloat(PlayerBombsDamage, _playerBombs.CurrentDamage);
        PlayerPrefs.SetFloat(PlayerBombsCooldown, _playerBombs.Interval.Duration);
        PlayerPrefs.SetInt(BulletUpgrade, _weapon.BulletIndex);
        PlayerPrefs.SetInt(WeaponUpgraded,_weaponHandler.UpgradeInt);

    }
    public void SetPlayer()
    {
        _playerHealth._currentHealth = PlayerPrefs.GetFloat(PlayerHealth, 5);
        _playerHealth.MaxHealth = PlayerPrefs.GetFloat(PlayerMaxHealth, 5);
        _playerArmor.CurrentArmor = PlayerPrefs.GetFloat(PlayerArmor, 3);
        _playerArmor.MaxArmor = PlayerPrefs.GetFloat(PlayerMaxArmor, 3);
        _playerBombs.CurrentDamage = PlayerPrefs.GetFloat(PlayerBombsDamage, 10);
        _playerBombs.Interval.Duration = PlayerPrefs.GetFloat(PlayerBombsCooldown, 8);
        _weapon.BulletIndex = PlayerPrefs.GetInt(BulletUpgrade, 0);
    }
}
