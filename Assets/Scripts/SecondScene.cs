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

    private Health _playerHealth;
    private Armor _playerArmor;
    private ThrowBombs _playerBombs;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _playerArmor = GameObject.FindGameObjectWithTag("Player").GetComponent<Armor>();
        _playerBombs = GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowBombs>();
        //SetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat(PlayerHealth, _playerHealth._currentHealth);
        PlayerPrefs.SetFloat(PlayerMaxHealth, _playerHealth.MaxHealth);
        PlayerPrefs.SetFloat(PlayerArmor, _playerArmor.CurrentArmor);
        PlayerPrefs.SetFloat(PlayerMaxArmor, _playerArmor.MaxArmor);


        NewHealth = PlayerPrefs.GetFloat("_currentHealth");
        NewMaxHealth = PlayerPrefs.GetFloat("MaxHealth");
        NewArmor = PlayerPrefs.GetFloat("CurrentArmor");
        NewMaxArmor = PlayerPrefs.GetFloat("MaxArmor");
        NewBombAmount = PlayerPrefs.GetFloat("Amount");
        NewMaxBomb = PlayerPrefs.GetFloat("MaxAmount");

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("PlayerHealth: " + PlayerPrefs.GetFloat(PlayerHealth).ToString());
            Debug.Log("PlayerMaxHealth: " + PlayerPrefs.GetFloat(PlayerMaxHealth).ToString());
            Debug.Log("PlayerArmor: " + PlayerPrefs.GetFloat(PlayerArmor).ToString());
            Debug.Log("PlayerMaxArmor: " + PlayerPrefs.GetFloat(PlayerMaxArmor).ToString());
        }
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
