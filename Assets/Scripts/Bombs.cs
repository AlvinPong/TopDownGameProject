  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    public float Damage = 10f;
    public float XSpeed = 10f;
    public float YSpeed = 10f;
    
    public LayerMask TargetLayerMask;

    public Cooldown LifeTime;

    public float Timer = 5f;

    public GameObject Trigger;

    private Rigidbody2D _rigidbody;
    private PlaySound _playsound;
    // Start is called before the first frame update
    void Start()
    {
        Trigger.SetActive(false);
        LifeTime.StartCooldown();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddRelativeForce(new Vector2(XSpeed, YSpeed));
        _playsound = GetComponent<PlaySound>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeTime.CurrentProgress != Cooldown.Progress.Finished)
            return;
        else
        {
            Explode();
            //BombExplodeSound();
            Invoke("Die", Timer);
        }
    }
    private void Explode()
    {
        BombExplodeSound();
        _rigidbody.velocity = Vector3.zero;
        Trigger.SetActive(true);
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
    private void BombExplodeSound()
    {
        _playsound.BombBoom();
    } 
    private void Die()
    {
        Destroy(gameObject);
    }
}
