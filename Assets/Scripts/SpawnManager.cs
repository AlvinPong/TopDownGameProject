using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int MaxPerZombie = 50;
    public int MaxPerWave = 50;
    public GameObject Zombie;

    public int CurrentZombies = 0;

    protected List<int> ZombieList = new List<int>();

    public float StartingInterval = 5f;
    public float SpawnInterval = 5f;
    public float SpawnTimer = 0f;

    public Transform[] SpawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTimer = StartingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnTimer >= 0)
        {
            SpawnTimer -= Time.deltaTime;
        }
        SpawnZombie();
    }
    public void Register(int id)
    {
        ZombieList.Add(id);
        //Debug.Log("Registering " + id);
    }
    public void Died(int id)
    {
        if (ZombieList.Contains(id))
        {
            CurrentZombies--;
            ZombieList.Remove(id);
            //Debug.Log("Removing " + id);
        }
    }
    public void SpawnZombie()
    {
        if (Zombie == null || SpawnTimer > 0 || MaxPerWave <= 0 || CurrentZombies >= MaxPerZombie) return;


        for (int i = 0; i < SpawnLocations.Length; i++)
        {
            Instantiate(Zombie, SpawnLocations[i].position, Quaternion.identity);
            CurrentZombies++;
            MaxPerWave--;
        }
        
        SpawnTimer = SpawnInterval;
    }
}
