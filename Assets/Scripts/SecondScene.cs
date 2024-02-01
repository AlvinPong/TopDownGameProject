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
    public string PlayerBombs = "PlayerCurrentBombs";
    public string PlayerMaxBombs = "PlayerMaxBombs";

    private Health _playerHealth;
    private Armor _playerArmor;
    private ThrowBombs _playerBombs;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _playerArmor = GameObject.FindGameObjectWithTag("Player").GetComponent<Armor>();
        _playerBombs = GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowBombs>();

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
        _playerHealth._currentHealth = PlayerPrefs.GetFloat(PlayerHealth);
        _playerHealth.MaxHealth = PlayerPrefs.GetFloat(PlayerMaxHealth);
        _playerArmor.CurrentArmor = PlayerPrefs.GetFloat(PlayerArmor);
        _playerArmor.MaxArmor = PlayerPrefs.GetFloat(PlayerMaxArmor);
        _playerBombs.Amount = PlayerPrefs.GetFloat(PlayerBombs);
        _playerBombs.MaxAmount = PlayerPrefs.GetFloat(PlayerMaxBombs);

    }
}
