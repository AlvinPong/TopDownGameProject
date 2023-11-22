using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    public float Damage = 10f;
    public float Speed = 10f;
    
    public LayerMask TargetLayerMask;

    public Cooldown LifeTime;

    public GameObject Trigger;
    // Start is called before the first frame update
    void Start()
    {
        Trigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeTime.CurrentProgress != Cooldown.Progress.Finished)
            return;
        else
        {
            Explode();
        }
    }
    private void Explode()
    {
        Trigger.SetActive(true);
        Invoke("Vanish", 1.5f);
    }
    private void Vanish()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
            return;

        Health targetHealth = col.gameObject.GetComponentInParent<Health>();

        if (targetHealth != null)
        {
            targetHealth.Damage(Damage, gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (!((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
            return;

        Health targetHealth = col.gameObject.GetComponentInParent<Health>();

        if (targetHealth != null)
        {
            targetHealth.Damage(Damage, gameObject);
        }
    }
}
