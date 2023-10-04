using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class Movement : MonoBehaviour
{
    public float Speed = 5f;
    public float DamageForce = 10f;
    public bool IsWalking
    {
        get
        {
            return _isWalking;
        }
    }
    public bool IsFacingUp
    {
        get
        {
            return _isFacingUp;
        }
    }
    public bool IsFacingDown
    {
        get
        {
            return _isFacingDown;
        }
    }
    public bool IsFacingSide
    {
        get
        {
            return _isFacingSide;
        }
    }
    public bool FlipAnim
    {
        get { return _flipAnim; }
        set { _flipAnim = value; }
    }

    protected Vector2 _inputDirection;

    protected bool _isWalking = false;
    protected bool _isFacingUp = false;
    protected bool _isFacingDown = true;
    protected bool _isFacingSide = false;

    protected bool _flipAnim = false;

    protected Rigidbody2D _rigidbody;

    private Health _health;
    private bool _disableInput = false;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        if (_health != null)
        {
            _health.OnHit += Hit;
            _health.OnHitReset += ResetMove;
        }
    }
    private void OnDisable()
    {
        if (_health != null)
        {
            _health.OnHit -= Hit;
            _health.OnHitReset -= ResetMove;
        }
    }
    private void ResetMove()
    {
        _disableInput = false;
    }
    private void Hit(GameObject source)
    {
        float pushHorizontal = 0f;
        float pushVertical = 0f;
        if (source != null)
        {
            if (source.transform.position.x < transform.position.x)
            {
                pushHorizontal = DamageForce;
            }
            else
            {
                pushHorizontal = -DamageForce;
            }
            if (source.transform.position.y < transform.position.y)
            {
                pushVertical = DamageForce;
            }
            else
            {
                pushVertical = -DamageForce;
            }
        }
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.velocity = new Vector2(pushHorizontal, pushVertical);

        _disableInput = true;
    }
    // Update is called once per frame
    void Update()
    {
        HandleInput();
        CheckDirection();
    }
    private void FixedUpdate()
    {
        HandleMovement();
        HandleAnim();        
    }
    protected virtual void HandleInput()
    {

    }
    protected virtual void HandleMovement()
    {
        if (_disableInput)
        {
            return;
        }
        if (_rigidbody == null)
            return;
        _rigidbody.velocity = new Vector2(_inputDirection.x * Speed, _inputDirection.y * Speed);
    }
    protected virtual void HandleAnim()
    {
        if (_inputDirection.x == 0 && _inputDirection.y == 0)
            _isWalking = false;
        else
        {
            _isWalking = true;
        }
    }   
    protected virtual void CheckDirection()
    {        
        if (Input.GetKeyDown(KeyCode.I)) //facing up
        {
            _isFacingUp = true;
            _isFacingDown = false;
            _isFacingSide = false;
        }
        if (Input.GetKeyDown(KeyCode.K)) //facing down
        {
            _isFacingUp = false;
            _isFacingDown = true;
            _isFacingSide = false;
        }
        if (Input.GetKeyDown(KeyCode.J)) //facing left
        {
            _flipAnim = true;
            _isFacingUp = false;
            _isFacingDown = false;
            _isFacingSide = true;
        }
        if (Input.GetKeyDown(KeyCode.L)) //facing right
        {
            _flipAnim = false;
            _isFacingUp = false;
            _isFacingDown = false;
            _isFacingSide = true;
        }

    }
}
