using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public GameObject[] fruitToSpawn;
    public Transform[] spawnPlaces;
    public static int score;
    public static int lives;

    [Header("Settings")]
    public float minWait = 1f;
    public float maxWait = 2f;
    public float minForce = 5;
    public float maxForce = 20;
    public int nextLife = 100;

    [Header("UI")]
    public Text scoreBoard;
    public Text livesCounter;
    public Text nextLifeCounter;

    void Start() {
        StartCoroutine(SpawnFruits());
        score = 0;
        lives = 3;
        nextLife = 100;
    }


    void Update() {

        if (lives <= 0) {
            Time.timeScale = 0;
            SceneManager.LoadScene("Lose");
        }

        if (score >= nextLife) {
            nextLife = nextLife * 2;
            lives++;
            nextLifeCounter.text = nextLife.ToString();
        }

        // Update High Score
        if (score > highScore) {
            highScore = score;
        }

        scoreBoard.text = score.ToString();
        livesCounter.text = lives.ToString();
    }


    private IEnumerator SpawnFruits() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            // Pick a random spawn place
            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            // Spawn a random fruit
            GameObject fruit = Instantiate(fruitToSpawn[Random.Range(0,fruitToSpawn.Length)], t.position, t.rotation);

            // Toss it
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce,maxForce), ForceMode2D.Impulse);

            // Destroy later
            Destroy(fruit, 10f);

        }
    }



}
