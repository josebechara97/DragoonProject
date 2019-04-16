using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSideways : MonoBehaviour {
    public float RotationSpeed;

    // Update is called once per frame
    void Update() {
        transform.Rotate(0, RotationSpeed, 0);
    }
}