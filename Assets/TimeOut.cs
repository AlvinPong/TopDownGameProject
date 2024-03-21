using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : MonoBehaviour
{
    public Cooldown Lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Lifetime.StartCooldown();
    }

    // Update is called once per frame
    void Update()
    {
        if(Lifetime.CurrentProgress == Cooldown.Progress.Finished )
        {
            gameObject.SetActive(false);
        }
    }
}
