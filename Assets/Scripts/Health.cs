using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject Drops;

    public bool _canDamage = true;

    public Cooldown Invulnerable;
    public Cooldown Stun;
    public float _currentHealth = 10f;
    public float MaxHealth = 10f;

    private HealthBarUI _healthBar;
    private Armor _armor;
    public EnemyHealthBar _enemyHealth;
    private PlaySound _playsound;
    private void Start()
    {
        
        _playsound = GetComponent<PlaySound>();
        if (gameObject.CompareTag("Player"))
        {
            _armor = GetComponent<Armor>();
            _healthBar = GameObject.Find("HealthBarUI").GetComponent<HealthBarUI>();
        }       
        if (_enemyHealth != null)
        {
            _enemyHealth.SetHealth(_currentHealth, MaxHealth);
        }
    }
    private void Update()
    {
        if (_healthBar != null)
        {
            _healthBar.SetHealth(_currentHealth / 10);
        }

        Heartbeat();
        ResetInvulnerble();
        ResetStun();
        if (Input.GetKeyUp(KeyCode.L) && gameObject.CompareTag("Enemy") || Input.GetKeyUp(KeyCode.L) && gameObject.CompareTag("Boss"))
        {
            Damage(100, gameObject);
        }
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
        if (!_canDamage) return;

        if (_armor != null && _armor.CurrentArmor > 0)
        {
            _armor.ArmorLoss(damageAmount);
        }
        else
        {
            _currentHealth -= damageAmount;
        }
        if (_healthBar != null)
        {
            _healthBar.SetHealth(_currentHealth / 10);
        }
        if (_enemyHealth != null)
        {
            _enemyHealth.SetHealth(_currentHealth, MaxHealth);
        }

        if (_currentHealth <= 0)
        {
            Die();
        }

        ZombieHurt();
        PlayerHurt();
        BossZombieHurt();

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
        if (Drops != null)
        {
            GameObject.Instantiate(Drops, transform.position, transform.rotation);
        }

        IsDead = true;
        _canDamage = false;
        Invoke("Dead", 0.2f);
    }

    public void Dead()
    {
        Destroy(this.gameObject);
    }
    public void Heartbeat()
    {
        if (!gameObject.CompareTag("Player"))
        {
            return;
        }

        if(_currentHealth <= 3)
        {
            //Debug.Log("health low, tyr play sound");

            _playsound.LowHealth();
        }
        
    }
    public void ZombieHurt()
    {
        if (!gameObject.CompareTag("Enemy"))
        {
            return;
        }

        _playsound.ZombieMoans();

    }
    public void PlayerHurt()
    {
        if (!gameObject.CompareTag("Player"))
        {
            return;
        }

        _playsound.PlayerMoan();

    }
    public void BossZombieHurt()
    {
        if (!gameObject.CompareTag("Boss"))
        {
            return;
        }

        _playsound.MiniBossSound();
    }
}

