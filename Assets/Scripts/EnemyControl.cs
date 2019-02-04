﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    public float Speed, Life;
    public int Weakness, GreatWeakness;

    private bool WentToTheScreen;

    private void Start()
    {
        WentToTheScreen = false;
    }

    private void OnBecameVisible()
    {
        WentToTheScreen = true;
    }

    private void OnBecameInvisible()
    {
        if (WentToTheScreen)
        {
            Destroy(gameObject);
        }
    }
}