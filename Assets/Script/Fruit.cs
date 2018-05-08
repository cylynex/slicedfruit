using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public GameObject slicedFruitPrefab;
    public int pointValue;

    void OnTriggerEnter2D(Collider2D collision) {
        Blade blade = collision.GetComponent<Blade>();
        if (!blade) {
            // did not impact blade, do nothing
            return;
        } else {
            
            // Slice baby slice
            CreateSlicedFruit();

            // Give player Points
            Game.score += pointValue;
        }
    }

    public void CreateSlicedFruit() {

        // Hide the fr00t
        MeshRenderer fruitMesh = GetComponent<MeshRenderer>();
        fruitMesh.enabled = false;
        gameObject.tag = "deadFruit";
        Collider2D coll = GetComponent<Collider2D>();
        coll.enabled = false;

        // Make noise
        AudioSource sliceIt = GetComponent<AudioSource>();
        sliceIt.Play();

        GameObject froot = (GameObject)Instantiate(slicedFruitPrefab,transform.position,transform.rotation);

        // create rigidbodies for explosion
        Rigidbody[] sliced = froot.transform.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rb in sliced) {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(200, 400), transform.position, 5f);
            Destroy(froot,5f); 
        }

        Destroy(gameObject,1f);
    }

}
