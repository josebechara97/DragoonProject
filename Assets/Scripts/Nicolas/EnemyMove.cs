using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    Rigidbody rb;
    GameObject tower;
    GameObject enemy;
    public GameObject player;
    public GameObject score;

    float angle;
    float distance;

    public float speed = 10.0f;
    private bool shrinking;
    private Transform towerTarget;
    private Transform playerTarget;

    bool isTouchingTower = false;

    // Start is called before the first frame update
    void Start()    {
        rb = GetComponent<Rigidbody>();

        tower = GameObject.FindGameObjectWithTag("Tower");
        enemy = GameObject.FindGameObjectWithTag("LandEnemy");
        player = GameObject.FindGameObjectWithTag("Player");

        towerTarget = tower.transform;
        playerTarget = player.transform;
        Vector3 directionToPlayer = transform.position - playerTarget.position;
        angle = Vector3.Angle(transform.forward, directionToPlayer);
        distance = directionToPlayer.magnitude;
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
        if (isTouchingTower == false) {
            transform.LookAt(towerTarget); //rotate to player
            transform.position = Vector3.MoveTowards(transform.position, towerTarget.position, step);
        }

        //Commented out by Luis because not sure if that is causing the problems
        /*
        // Rotate 90 degrees to the right and move 20 spaces if near PLAYER
        if (Mathf.Abs(angle) < 90 && distance < 10) {
            transform.Rotate(Vector3.right * 90);
            transform.Translate(Vector3.forward * 20);
            //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }*/
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
        }
    }
}
