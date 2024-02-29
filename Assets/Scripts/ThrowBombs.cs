using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThrowBombs : MonoBehaviour
{
    public GameObject Explosive;
    public Transform SpawnPos;

    public Cooldown Interval;
    
    protected Movement _movement;

    public TMP_Text BombTimer;

    public Bombs bombs;
    public float CurrentDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        BombTimer = GameObject.Find("BombAmount").GetComponent<TMP_Text>();
        _movement = GetComponent<Movement>();
        bombs = Explosive.GetComponent<Bombs>();
        
        bombs.Damage = CurrentDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (BombTimer != null)
        {
            if (Interval.CurrentProgress == Cooldown.Progress.Ready)
            {
                BombTimer.text = "READY";
            }
            else
            {
                BombTimer.text = "Wait";
            }
        }
        HandleInput();
        if (Interval.CurrentProgress != Cooldown.Progress.Finished)
            return;
        Interval.CurrentProgress = Cooldown.Progress.Ready;
    }
    private void HandleInput()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ThrowExplosive();
        }
    }
    private void ThrowExplosive()
    {
        if (Interval.CurrentProgress != Cooldown.Progress.Ready)
            return;

        GameObject explosive = GameObject.Instantiate(Explosive, SpawnPos.position, SpawnPos.rotation);

        

        if (_movement.IsFacingUp)
        {
            explosive.GetComponent<Bombs>().XSpeed *= 0;
            explosive.GetComponent<Bombs>().YSpeed *= 1;
        }
        if (_movement.IsFacingDown)
        {
            explosive.GetComponent<Bombs>().XSpeed *= 0;
            explosive.GetComponent<Bombs>().YSpeed *= -1;
        }
        if(_movement.IsFacingSide && _movement.FlipAnim)
        {
            explosive.GetComponent<Bombs>().XSpeed *= -1;
            explosive.GetComponent<Bombs>().YSpeed *= 0;
        }
        if(_movement.IsFacingSide && !_movement.FlipAnim)
        {
            explosive.GetComponent<Bombs>().XSpeed *= 1;
            explosive.GetComponent<Bombs>().YSpeed *= 0;
        }

        Interval.StartCooldown();
    }
    public void CooldownUpgrade()
    {
        Interval.Duration -= 1;
    }
    public void DamageUpgrade()
    {
        if(Explosive != null)
        {
            bombs.Damage += 10;
            CurrentDamage += 10;
        }
    }   
}
