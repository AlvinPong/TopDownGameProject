using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRage : MonoBehaviour
{
    private EnemyMovement movement;
    private Health health;
    private Damager damager;      
    EnemyBoss enemyboss;
    private void Start()
    {
        movement = GetComponent<EnemyMovement>(); 
        damager = GetComponent<Damager>();
        health = GetComponent<Health>();
        //enemyboss = new EnemyBoss(movement.Acceleration, damager.Damage, health.MaxHealth, health.CurrentHealth);
    }

    private void Update()
    {
        enemyboss = new EnemyBoss(movement.Acceleration, damager.Damage, health.MaxHealth, health.CurrentHealth);
        enemyboss.CheckHealth();
    }


    public class EnemyBoss
    {
        public float MovementSpeed { get; private set; }
        public float Damage { get; private set; }
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        //public bool IsInRageState { get; private set; }
        public bool IsInRageState = false;
        public EnemyBoss(float movementSpeed, float damage, float maxHealth, float currentHealth)
        {
            MovementSpeed = movementSpeed;
            Damage = damage;
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }
        public void CheckHealth()
        {
            if (CurrentHealth < MaxHealth * 0.5 && !IsInRageState)
            {            
                if (IsInRageState == false)
                {
                    EnterRageState();
                    Debug.Log("Trigger Rage State");
                }
                
            }
            else
            {
                ExitRageState();
            }
        }

        public void EnterRageState()
        {
           
            MovementSpeed *= 10f; 
            Damage *= 5; 
            IsInRageState = true;
            Debug.Log("Enter Rage State");
        }

        public void ExitRageState()
        {
            MovementSpeed /= 10f; 
            Damage /= 5; 
            IsInRageState = false;
            IsInRageState = true;
            Debug.Log("exit");
            
        }

    }
}
