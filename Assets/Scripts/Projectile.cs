using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage = 1f;
    public float Speed = 10f;
    public float PushForce = 10f;
    public Cooldown LifeTime;
    public LayerMask TargetLayerMask;
    public LayerMask HeadLayerMask;

    public Rigidbody2D _rigidbody;


    private PlaySound _playsound;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        LifeTime.StartCooldown();
        _rigidbody.AddRelativeForce(new Vector2(Speed, 0f));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeTime.CurrentProgress != Cooldown.Progress.Finished)
            return;

       
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
            return;
        Rigidbody2D targetRigidbody = col.gameObject.GetComponent<Rigidbody2D>();

        if (targetRigidbody != null)
        {
            targetRigidbody.AddForce((col.transform.position - transform.position).normalized * PushForce);
        }

        Health targetHealth = col.gameObject.GetComponentInParent<Health>();

        if (targetHealth != null)
        {
            if (!((HeadLayerMask.value & (1 << col.gameObject.layer)) > 0))
            {
                targetHealth.Damage(Damage, gameObject);
            }
            else
            {
                targetHealth.Damage(1.5f * Damage, gameObject);
            }
        }

        EnemyMovement _enemy = col.gameObject.GetComponent<EnemyMovement>();
        if(_enemy != null)
        {
            _enemy.IsStunned = true;
        }

        Die();
    }
    
}
