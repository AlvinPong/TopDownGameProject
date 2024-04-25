using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    
    public float DashingTime = 0.5f;
    public float DashingVelocity = 10f;
    private Vector2 _dashingDirection;

    public Cooldown DashCooldown;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _dashingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (_dashingDirection == Vector2.zero)
        {
            _dashingDirection = new Vector2(transform.localScale.x, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
            Debug.Log("Dash Pressed");
        }
        if (DashCooldown.CurrentProgress != Cooldown.Progress.Finished)
            return;
        DashCooldown.CurrentProgress = Cooldown.Progress.Ready;
    }
    protected void Dash()
    {
        if (DashCooldown.CurrentProgress != Cooldown.Progress.Ready)
            return;
        _rigidbody.velocity = _dashingDirection * DashingVelocity;
        Debug.Log("Dash");
        
        DashCooldown.StartCooldown();
    }
}
