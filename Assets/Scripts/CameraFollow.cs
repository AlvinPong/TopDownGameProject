using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject _player;
    public Vector2 PositionOffset = Vector2.zero;
    public float LerpSpeed = 5.0f;
    protected float targetXPos = 0f;
    protected float targetYPos = 0f;

    protected float MaxPosX = 12f;
    protected float MaxPosY = 5f;
    protected float MinPosX = -12f;
    protected float MinPosY = -5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (_player == null)
            return;


        targetXPos = Mathf.Lerp(targetXPos, _player.transform.position.x, Time.deltaTime * LerpSpeed);
        targetYPos = Mathf.Lerp(targetYPos, _player.transform.position.y, Time.deltaTime * LerpSpeed);

        float xPos = Mathf.Clamp(targetXPos, MinPosX + 7, MaxPosX - 7);
        float yPos = Mathf.Clamp(targetYPos, MinPosY + 2.5f, MaxPosY - 2.5f);

        transform.position = new Vector3(xPos, yPos, -10f);
    }
}
