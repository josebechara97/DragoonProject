using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour {
    public float health;
    public Text healthLabel;
    public Text thoughts;
    static System.Random rnd = new System.Random();
    private List<GameObject> spawns;
    private float wait = 2;
    private int timesspawned = 0;
    public GameObject score;

    private void Start() {
       spawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("Spawnpoints"));
       health += 100.0f;
    }

    // Update is called once per frame
    void Update() {
        wait -= Time.deltaTime;
        if (wait <= 0) {
            timesspawned += 1;
            GameObject clone = Instantiate(GameObject.FindGameObjectWithTag("LandEnemy"));
            int r = rnd.Next(spawns.Count);
            clone.transform.position = spawns[r].transform.position;
            clone.GetComponent<EnemyMove>().speed *= timesspawned;
            clone.SetActive(true);
            wait = 2;
        }

        healthLabel.text = "Tower Health: " + Math.Round(health);
        if (health <= 0) {
            Destroy(this.gameObject);
        }
    }

    public void Subtract() {
        health -= 1.0f;
    }

    private void OnDestroy() {
        Destroy(score);
        if (thoughts) {
            thoughts.text = "No... I failed...";
        }
    }
}
