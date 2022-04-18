// Written by Josh Xiong
// 3/12/2022
// Singleton
// Purpose: ensures class has one instance globally

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Music : MonoBehaviour
{
    private static Music instance;

    public void Awake()
    {
        // Delete newly created music for each scene
        if (instance != null)
        {
            Destroy(gameObject);
        }
        // Don't destroy instance when moving to new scene
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
