using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resupplies : MonoBehaviour
{
    private Health _health;
    private Armor _armor;
    private ThrowBombs _bombs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        _health = col.gameObject.GetComponent<Health>();
        _armor = col.gameObject.GetComponent<Armor>();
        _bombs = col.gameObject.GetComponent<ThrowBombs>();

        _health._currentHealth = _health.MaxHealth;
        _armor.CurrentArmor = _armor.MaxArmor;
        _bombs.Amount = _bombs.MaxAmount;

        Vanish();
    }
    private void Vanish()
    {
        Destroy(this.gameObject);
    }
}
