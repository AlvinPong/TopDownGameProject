using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThrowBombs : MonoBehaviour
{
    public GameObject Explosive;
    public Transform SpawnPos;

    public Cooldown Interval;

    public float Amount = 5;

    protected Movement _movement;

    public TMP_Text BombAmount;
    // Start is called before the first frame update
    void Start()
    {
        BombAmount = GameObject.Find("BombUI").GetComponent<TMP_Text>();
        _movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BombAmount != null)
            BombAmount.text = Amount.ToString();

        HandleInput();
        if (Interval.CurrentProgress != Cooldown.Progress.Finished)
            return;
        Interval.CurrentProgress = Cooldown.Progress.Ready;
    }
    private void HandleInput()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            if (Amount > 0)
            {
                ThrowExplosive();
            }
        }
    }
    private void ThrowExplosive()
    {
        if (Interval.CurrentProgress != Cooldown.Progress.Ready)
            return;

        GameObject explosive = GameObject.Instantiate(Explosive, SpawnPos.position, SpawnPos.rotation);

        Amount -= 1;

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
}
