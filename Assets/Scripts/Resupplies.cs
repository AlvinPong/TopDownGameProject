using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resupplies : MonoBehaviour
{
    private Health _health;
    private Armor _armor;

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

        _health._currentHealth = _health.MaxHealth;
        _armor.CurrentArmor = _armor.MaxArmor;

        Vanish();
    }
    private void Vanish()
    {
        Destroy(this.gameObject);
    }
}
