using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public float SpawnAmount = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DecreaseAmount(float value)
    {
        if (SpawnAmount <= 0) return;
        SpawnAmount -= value;
    }
}
