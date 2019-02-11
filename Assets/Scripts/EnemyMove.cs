using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public Rigidbody rb;
    GameObject tower;
    GameObject enemy;
    public GameObject player;

    float angle;
    float distance;

    public float speed = 10.0f;
    private Transform towerTarget;
    private Transform playerTarget;

    bool isTouchingTower = false;

    // Start is called before the first frame update
    void Start()
    {

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
    void FixedUpdate()
    {
        // Moves enemy towards Tower
        float step = speed * Time.deltaTime; // calculate distance to move
        if (isTouchingTower == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, towerTarget.position, step);
        }

        // Rotate 90 degrees to the right and move 20 spaces if near PLAYER
        if (Mathf.Abs(angle) < 90 && distance < 10) {
            transform.Rotate(Vector3.right * 90);
            transform.Translate(Vector3.forward * 20);
            //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        // Tested but did not recognize player, I believe the MoveTowards function in FixedUpdate 
        // overrules this.
        if (other.gameObject.CompareTag("Player"))
        {
            transform.Rotate(Vector3.right * 90);
            transform.Translate(Vector3.forward * 20);
        }

        if (other.gameObject.CompareTag("Tower"))
        {
            isTouchingTower = true;
            speed = 0;

        }
    }
}
