using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    protected override void HandleInput()
    {
        _inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _inputFacingDirection = Vector2.zero;
            _inputFacingDirection.y++;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            _inputFacingDirection = Vector2.zero;
            _inputFacingDirection.y--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _inputFacingDirection = Vector2.zero;
            _inputFacingDirection.x++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _inputFacingDirection = Vector2.zero;
            _inputFacingDirection.x--;
        }
    }
}
