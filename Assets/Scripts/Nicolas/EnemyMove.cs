using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float speed = 10.0f;
    public GameObject score;

    private bool shrinking = false;
    private bool isTouchingTower = false;
    private float cooldown = 0;
    private GameObject tower;

    private void Start() {
        tower = GameObject.FindGameObjectWithTag("Tower");
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (shrinking) {
            transform.localScale *= 0.9f;
            if (transform.localScale.x < 0.1f) {
                Destroy(this.gameObject);
            }
        }
        // Moves enemy towards Tower
        float step = speed * Time.deltaTime; // calculate distance to move
        if (!isTouchingTower) {
            transform.LookAt(tower.transform);
            transform.position = Vector3.MoveTowards(transform.position, tower.transform.position, step);
        } else if (!shrinking) {
            cooldown -= Time.deltaTime;
            if (cooldown < 1) {
                Attack();
            }
        }
    }

    private void OnCollisionEnter(Collision other) {

        // Tested but did not recognize player, I believe the MoveTowards function in FixedUpdate 
        // overrules this.
        if (other.gameObject.tag == "Player") {
            shrinking = true;
            score.GetComponent<ScoreManagement>().kills++;
        }

        if (other.gameObject.CompareTag("Tower")) {
            isTouchingTower = true;
            speed = 0;
            Attack();
        }
    }

    void Attack() {
        tower.GetComponent<Tower>().Subtract();
        cooldown = 3;
    }
}
