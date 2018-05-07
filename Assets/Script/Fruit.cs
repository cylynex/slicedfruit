using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public GameObject slicedFruitPrefab;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            CreateSlicedFruit();
        }
    }


    void OnTriggerEnter2D(Collider2D collision) {
        Blade blade = collision.GetComponent<Blade>();
        if (!blade) {
            // did not impact blade, do nothing
            return;
        } else {
            // Slice baby slice
            CreateSlicedFruit();
        }
    }

    public void CreateSlicedFruit() {
        GameObject froot = (GameObject)Instantiate(slicedFruitPrefab,transform.position,transform.rotation);

        // create rigidbodies for explosion
        Rigidbody[] sliced = froot.transform.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rb in sliced) {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(200, 400), transform.position, 5f);
            Destroy(froot,5f); 
        }

        Destroy(gameObject);
    }

}
