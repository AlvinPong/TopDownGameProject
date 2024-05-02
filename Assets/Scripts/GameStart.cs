using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public string PlayerHealth = "PlayerCurrentHealth";
    public string PlayerMaxHealth = "PlayerMaxHealth";
    public string PlayerArmor = "PlayerCurrentArmor";
    public string PlayerMaxArmor = "PlayerMaxArmor";
    public string PlayerBombs = "PlayerCurrentBombs";
    public string PlayerMaxBombs = "PlayerMaxBombs";

    public string HealthUpgrade = "ShopHealthUpgrade";
    public string ArmorUpgrade = "ShopArmorUpgrade";
    public string BombUpgrade = "ShopBombUpgrade";

    public string SavedCoins = "PlayerSavedCoins";

    public string BulletUpgrade = "CurrentBullet";

    public string WeaponUpgraded = "WeaponUpgraded";
    // Start is called before the first frame update
    void Start()
    {
        PlayerSetUp();
        ShopSetUp();
        ScoreSetUp();
        PlayerPrefs.SetInt(BulletUpgrade, 0);
        PlayerPrefs.SetInt(WeaponUpgraded, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerSetUp()
    {
        PlayerPrefs.SetFloat(PlayerHealth, 5);
        PlayerPrefs.SetFloat(PlayerMaxHealth, 5);
        PlayerPrefs.SetFloat(PlayerArmor, 3);
        PlayerPrefs.SetFloat(PlayerMaxArmor, 3);
        PlayerPrefs.SetFloat(PlayerBombs, 0);
        PlayerPrefs.SetFloat(PlayerMaxBombs, 0);
    }
    public void ShopSetUp()
    {
        PlayerPrefs.SetInt(HealthUpgrade, 0);
        PlayerPrefs.SetInt(ArmorUpgrade, 0);
        PlayerPrefs.SetInt(BombUpgrade, 0);
    }
    public void ScoreSetUp()
    {
        PlayerPrefs.SetInt(SavedCoins, 0);
    }
}
