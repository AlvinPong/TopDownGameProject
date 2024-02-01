using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    private Health _health;
    private Armor _armor;
    private ThrowBombs _bombs;
   
    // Start is called before the first frame update
    void Start()
    {
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _armor = GameObject.FindGameObjectWithTag("Player").GetComponent<Armor>();
        _bombs = GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowBombs>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            _health._currentHealth = 5;
            _health.MaxHealth = 5;
            _armor.CurrentArmor = 3;
            _armor.MaxArmor = 3;
            _bombs.Amount = 0;
            _bombs.MaxAmount = 0;
        }
    }
}
