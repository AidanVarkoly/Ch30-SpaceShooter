using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    [Header("Set in the Inspector")]
    public float waveFrequancy = 2;
    public float waveWidth = 4;
    public float waveRotY = 45;

    private float x0;
    private float birthTime;

    void Start()
    {
        x0 = pos.x;

        birthTime = Time.time;
        
    }
    public override void Move()
    {
        Vector3 tempPos = pos;
        float age = Time.time - birthTime;
        float thets = Mathf.PI * 2 * age / waveFrequancy;
        float sin = Mathf.Sin(thets);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;

        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);

        base.Move();
    }
}
