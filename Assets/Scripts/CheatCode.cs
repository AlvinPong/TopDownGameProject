using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    private Health _health;
    private Armor _armor;
    private ThrowBombs _bombs;

    private ShopUI _shopUI;

    private ScoreManager _scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _armor = GameObject.FindGameObjectWithTag("Player").GetComponent<Armor>();
        _bombs = GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowBombs>();
        _shopUI = GameObject.Find("Shop").GetComponentInChildren<ShopUI>();
        _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("RESET ALL");
            _health._currentHealth = 5;
            _health.MaxHealth = 5;
            _armor.CurrentArmor = 3;
            _armor.MaxArmor = 3;
            _bombs.Amount = 0;
            _bombs.MaxAmount = 0;

            _shopUI.HealthInput = 0;
            _shopUI.ArmorInput = 0;
            _shopUI.BombInput = 0;
            PlayerPrefs.SetInt(_shopUI.HealthUpgrade, 0);
            PlayerPrefs.SetInt(_shopUI.ArmorUpgrade, 0);
            PlayerPrefs.SetInt(_shopUI.BombUpgrade, 0);

            _scoreManager.CoinAmount = 100;
        }
    }
}
