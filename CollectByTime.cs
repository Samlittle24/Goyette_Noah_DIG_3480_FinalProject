﻿using UnityEngine;
using System.Collections;

public class CollectByTime : MonoBehaviour
{
    public float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}