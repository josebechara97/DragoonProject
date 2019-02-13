using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterKiller : MonoBehaviour {
    private void OnTriggerEnter(Collider collision) {
        Debug.Log("Triggered");
        if (collision.gameObject.tag == "Player") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

