using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loselife : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log(coll.gameObject.tag);
        Game.lives--;
    }
}
