using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScale : MonoBehaviour
{
    private Animator _animator;
    private EnemyMovement _movement;

    private Vector3 _initialScale = Vector3.one;
    private Vector3 _flipScale = Vector3.one;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = transform.parent.GetComponent<EnemyMovement>();

        _initialScale = transform.localScale;
        _flipScale = new Vector3(-_initialScale.x, _initialScale.y, _initialScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        HandleFlip();
    }
    private void HandleFlip()
    {
        if (_movement == null) { return; }

        if (_movement.FlipAnim)
        {
            transform.localScale = _flipScale;
        }
        else
        {
            transform.localScale = _initialScale;
        }
    }
}
