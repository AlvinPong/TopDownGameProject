using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{
    private SpawnManager _spawnManager;
    private Health _health;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        if (_spawnManager != null)
        {
            _spawnManager.Register(gameObject.GetInstanceID());
            Debug.Log(gameObject.GetInstanceID());
        }

        _health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_health == null)
        {
            Debug.Log(" no health");
            return;
        }
        if (_health.IsDead)
            Debug.Log("dead");

        if(_health._currentHealth <= 0)
        {
            if (_spawnManager != null)
            {
                _spawnManager.Died(gameObject.GetInstanceID());
                Debug.Log("I am ded");
            }
        }
    }
}
