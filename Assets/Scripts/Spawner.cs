using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _gameObject;
    public float StartingInterval = 0f;
    public float SpawnInterval = 2f;
    public float SpawnTimer = 0f;
    private Health _health;

    //private PauseManager _pauseManager;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTimer = StartingInterval;
        //_pauseManager = GameObject.Find("PauseManager").GetComponent<PauseManager>();
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (_pauseManager.IsPause == true)
        //    return;
        if (_health.CurrentHealth <= 0) return;
        if (SpawnTimer >= 0)
        {
            SpawnTimer -= Time.deltaTime;
        }
        else
        {
            Vector3 targetposition = transform.position;
            GameObject.Instantiate(_gameObject, targetposition, Quaternion.identity);
            SpawnTimer = SpawnInterval;
        }
    }
}
