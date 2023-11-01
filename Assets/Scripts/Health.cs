using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void HitEvent(GameObject source);
    public HitEvent OnHit;

    public delegate void ResetEvent();
    public ResetEvent OnHitReset;
    public ResetEvent OnReset;
     
    public bool IsDead = false;
    //public
    public float CurrentHealth
    {
        get { return _currentHealth; }
    }
    public GameObject DeathParticles;

    public bool _canDamage = true;

    public Cooldown Invulnerable;
    public Cooldown Stun;
    public float _currentHealth = 10f;

    private void Update()
    {
        ResetInvulnerble();
        ResetStun();
    }
    private void ResetInvulnerble()
    {
        if (_canDamage)
            return;
        if (Invulnerable.IsOnCooldown && _canDamage == false)
            return;
        _canDamage = true;
        
        OnHitReset?.Invoke();
    }
    private void ResetStun()
    {
        if (Stun.IsOnCooldown) return;
        OnReset?.Invoke();
    }
    public void Damage(float damageAmount, GameObject source)
    {
        if (!_canDamage) 
            return;
        _currentHealth -= damageAmount;
        if (_currentHealth <= 0)
        {
            Die();
        }

        Invulnerable.StartCooldown();
        Stun.StartCooldown();
        _canDamage = false;

        OnHit?.Invoke(source);
    }
    public void Die()
    {
        //Debug.Log("You Died");
        if (DeathParticles != null)
        {
            GameObject.Instantiate(DeathParticles, transform.position, transform.rotation);
        }
        Destroy(this.gameObject);
        Dead();
    }

    public void Dead()
    {
        IsDead = true;
    }
}
