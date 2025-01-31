﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float rotationsPerSecond = 0.1f;

    [Header("Set Dynamically")]
    public int levelShown = 0;

    // This non-public variable will not appear in the inspector
    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Read the current sheild level from the Hero Singleton
        int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel);

        // If this is different from LevelShown...
        if (levelShown != currLevel)
        {
            levelShown = currLevel;

            // Adjust the texture offset to show different level shield
            mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
        }
        // Rotate the shield a bit every fram in a time-based way
        float rZ = -(rotationsPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
