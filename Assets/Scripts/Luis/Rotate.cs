﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public float RotationSpeed;
  
    // Update is called once per frame
    void Update() {
        transform.Rotate(RotationSpeed, 0, 0);
    }
}