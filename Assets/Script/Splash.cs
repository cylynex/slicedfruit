using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour {

    public float autoLoadNextLevelAfter = 5f;

    // Use this for initialization
    void Start() {
        Invoke("LoadNextLevel", 10f);
    }

    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
