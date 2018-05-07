using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loselife : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "wholeFruit") {
            Game.lives--;
        }
    }
}
