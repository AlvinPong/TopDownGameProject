using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBombs : MonoBehaviour
{
    public GameObject Explosive;
    public Transform SpawnPos;

    public Cooldown Interval;

    protected float Amount = 5;

    protected Movement _movement;
    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        if (Interval.CurrentProgress != Cooldown.Progress.Finished)
            return;
        Interval.CurrentProgress = Cooldown.Progress.Ready;
    }
    private void HandleInput()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            ThrowExplosive();
        }
    }
    private void ThrowExplosive()
    {
        if (Interval.CurrentProgress != Cooldown.Progress.Ready)
            return;

        GameObject explosive = GameObject.Instantiate(Explosive, SpawnPos.position, SpawnPos.rotation);

        //if (_isFlip)
        //    explosive.GetComponent<Projectile>().Speed *= -1;

        Interval.StartCooldown();
    }
}
