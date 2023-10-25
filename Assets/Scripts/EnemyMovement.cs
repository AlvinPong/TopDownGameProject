using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Acceleration = 1f;
    private Transform _player;
    protected Vector2 _movingDirection;
    private Rigidbody2D _rigidbody;
    public bool FlipAnim
    {
        get { return _flipAnim; }
        set { _flipAnim = value; }
    }
    protected bool _flipAnim;
    private Health _health;
    public PhysicsMaterial2D Friction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
    private void Update()
    {
        HandleMovement();
    }
    protected void HandleMovement()
    {
        if (_health.CurrentHealth <= 0) return;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        
        Vector2 target = new Vector2(_player.position.x, _player.position.y);
        Vector2 newPos = Vector2.MoveTowards(_rigidbody.position, target, Acceleration * Time.fixedDeltaTime);
        _rigidbody.MovePosition(newPos);
        _movingDirection = newPos;
        _rigidbody.sharedMaterial = Friction;
        if (target.x > transform.position.x)
        {
            _flipAnim = false;
        }
        else
        {
            _flipAnim = true;
        }
    }    
}
