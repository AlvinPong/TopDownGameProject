using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    
    public GameObject _attackTrigger;
    public Transform SpawnPos;
    public Cooldown AttackInterval;

    public bool IsFlip
    {
        set { _isFlip = value; }
    }

    public bool _isFlip = false;

    private Movement _movement;
    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AttackInterval.CurrentProgress != Cooldown.Progress.Finished)
            return;
        AttackInterval.CurrentProgress = Cooldown.Progress.Ready;
    }
    public void HandleAttack()
    {
        if (AttackInterval.CurrentProgress != Cooldown.Progress.Ready)
            return;
        GameObject.Instantiate(_attackTrigger,SpawnPos.position, SpawnPos.rotation);
        if (_isFlip)
        {
            _attackTrigger.transform.localScale = new Vector3(-1, 1, 1);
        }
        AttackInterval.StartCooldown();
    }
}