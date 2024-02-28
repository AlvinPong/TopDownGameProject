using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCutscene : MonoBehaviour
{
    public GameObject _MiniBoss;
    public Vector2 PositionOffset = Vector2.zero;
    public float LerpSpeed = 5.0f;
    protected float targetXPos = 0f;
    protected float targetYPos = 0f;

    public float MaxPosX = 12f;
    public float MaxPosY = 5f;
    public float MinPosX = -12f;
    public float MinPosY = -5f;

    void FixedUpdate()
    {
        MiniBoss();
    }

    void MiniBoss()
    {
        GameObject.FindGameObjectsWithTag("Boss");


    }
}
