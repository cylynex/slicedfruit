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
    public static int level;
    public static int highScore;

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

    private GameObject fruit;
    private Transform placeToSpawn;

    void Start() {
        StartCoroutine(SpawnFruits());
        score = 0;
        lives = 3;
        nextLife = 100;
        level = 1;
        Time.timeScale = 1;
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
            level++;
        }

        // Update High Score
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("HighScore",highScore);
        }

        scoreBoard.text = score.ToString();
        livesCounter.text = lives.ToString();
    }


    private IEnumerator SpawnFruits() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            // Spawn a random fruit
            for (int i = 1; i <= level; i++) {

                // Pick a random spawn place
                placeToSpawn = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

                // Instantiate the Fruit
                fruit = Instantiate(fruitToSpawn[Random.Range(0, fruitToSpawn.Length)], placeToSpawn.position, placeToSpawn.rotation);

                // Toss it
                int whichway = Random.Range(1, 2);
                switch (whichway) {
                    case 1:
                        fruit.GetComponent<Rigidbody2D>().AddForce(placeToSpawn.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
                        break;
                    case 2:
                        fruit.GetComponent<Rigidbody2D>().AddForce(placeToSpawn.transform.right * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
                        break;
                }

                // Destroy later
                Destroy(fruit, 10f);
            }
        }
    }

}
