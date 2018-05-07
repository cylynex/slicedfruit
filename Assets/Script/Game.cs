using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public GameObject fruitToSpawn;
    public Transform[] spawnPlaces;

    [Header("Settings")]
    public float minWait = 1f;
    public float maxWait = 2f;
    public float minForce = 5;
    public float maxForce = 20;

    void Start() {
        StartCoroutine(SpawnFruits());
    }


    private IEnumerator SpawnFruits() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            // Pick a random spawn place
            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            // Spawn
            GameObject fruit = Instantiate(fruitToSpawn, t.position, t.rotation);

            // Toss it
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce,maxForce), ForceMode2D.Impulse);

            // Destroy later
            Destroy(fruit, 10f);

        }
    }
}
