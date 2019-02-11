using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : MonoBehaviour
{

    public int Health = 100;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Health: " + Health);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LandEnemy"))
        {
            InvokeRepeating("Subtract", 1f, 1f);
        }
    }

    void Subtract()
    {
        Health -= 1;

    }

}



