using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public static float health;
    public Text healthLabel;
    public int Health = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        healthLabel.text = "Tower Health: " + health;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("LandEnemy")) {
            InvokeRepeating("Subtract", 1f, 1f);
        }
    }

    void Subtract() {
        health -= 1;

    }
}
