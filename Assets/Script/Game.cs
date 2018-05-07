using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public GameObject fruitToSpawn;
    public Transform[] spawnPlaces;

    public float minWait = 1f;
    public float maxWait = 2f;

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
            fruit.GetComponent<Rigidbody2D>().AddForce(transform.up * 10, ForceMode2D.Impulse);

            // Destroy later
            Destroy(fruit, 10f);

        }
    }
}
