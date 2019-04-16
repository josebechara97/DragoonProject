using System;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour {
    public float health;
    public Text healthLabel;
    public Text thoughts;

    private void Start() {
       health += 100.0f;
    }

    // Update is called once per frame
    void Update() {
        healthLabel.text = "Tower Health: " + Math.Round(health);
        if (health <= 0) {
            Destroy(this.gameObject);
        }
    }

    public void Subtract() {
        health -= 1.0f;
    }

    private void OnDestroy() {
        if (thoughts) {
            thoughts.text = "No... I failed...";
        }
    }
}
