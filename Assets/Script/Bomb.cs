using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision) {
        Blade b = collision.GetComponent<Blade>();
        if (b) {
            Debug.Log("hit by blade");
        }
    }

}
