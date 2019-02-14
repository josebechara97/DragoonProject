using System;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public float health;
    public Text healthLabel;

    private void Start() {
       health += 100.0f;
    }

    // Update is called once per frame
    void Update() {
        healthLabel.text = "Tower Health: " + Math.Round(health);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("LandEnemy")) {
            InvokeRepeating("Subtract", 1.0f, 1.0f);
        }
    }

    void Subtract() {
        health -= 1.0f;
    }
}
