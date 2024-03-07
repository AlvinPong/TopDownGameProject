using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrow : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;
    private Rigidbody2D _rigidbody;

    private float angle;

    public GameObject projectile;
    public Transform SpawnPos;
    public Cooldown ShootInterval;

    public bool IsFlip
    {
        set { _isFlip = value; }
    }

    public bool _isFlip = false;

    private EnemyMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        //getting player component
        _playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        //getting current enemy component
        _rigidbody = GetComponent<Rigidbody2D>();

        movement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ThrowStone();
        if (ShootInterval.CurrentProgress != Cooldown.Progress.Finished)
            return;
        ShootInterval.CurrentProgress = Cooldown.Progress.Ready;
    }
    private void FixedUpdate()
    {
        Vector2 Direction = _playerRigidbody.position - _rigidbody.position;
        angle = Mathf.Atan2(Direction.x, Direction.y) * Mathf.Rad2Deg * -1;
        SpawnPos.GetComponent<Rigidbody2D>().rotation = angle + 90;
    }
    public void ThrowStone()
    {
        if (ShootInterval.CurrentProgress != Cooldown.Progress.Ready)
            return;

        GameObject bullet = GameObject.Instantiate(projectile, SpawnPos.position, SpawnPos.rotation);

        if (_isFlip)
        {
            bullet.transform.localScale = new Vector3(-1, 1, 1);
        }
        ShootInterval.StartCooldown();
    }
}
