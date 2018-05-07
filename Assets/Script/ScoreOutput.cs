using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreOutput : MonoBehaviour {

    public Text score;
    public Text highScore;
    public int loadScreen = 0;

    void Awake() {
        if (loadScreen == 0) {
            score.text = Game.score.ToString();
        }

        int hs = PlayerPrefs.GetInt("HighScore");
        highScore.text = hs.ToString();
    }

}
