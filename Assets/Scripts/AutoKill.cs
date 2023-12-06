using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKill : MonoBehaviour
{
    public float Timer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(autokill());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator autokill()
    {
        yield return new WaitForSeconds(Timer);
        Destroy(gameObject);
    }
}
