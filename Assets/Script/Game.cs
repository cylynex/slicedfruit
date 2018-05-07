using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public GameObject fruitToSpawn;
    public float minWait = 200f;
    public float maxWait = 600f;

    void Update() {
        StartCoroutine(SpawnFruits());
    }


    private IEnumerator SpawnFruits() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            Debug.Log("Fruit Spawned now");
            Instantiate(fruitToSpawn);
        }
    }
}
