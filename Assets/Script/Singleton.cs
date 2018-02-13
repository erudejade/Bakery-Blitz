﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour  {
    public static T instance;

    protected void Awake() {
        if (instance == null)
            instance = GetComponent<T>();
        else
            Debug.LogError("Error Singleton");
    }
}
