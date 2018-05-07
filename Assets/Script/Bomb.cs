using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision) {
        Blade b = collision.GetComponent<Blade>();
        if (b) {

            // Sound
            AudioSource boom = GetComponent<AudioSource>();
            boom.Play();

            // Particles
            ParticleSystem explosion = GetComponent<ParticleSystem>();
            explosion.Play();

            // Poof the bomb itself
            MeshRenderer dabomb = GetComponent<MeshRenderer>();
            dabomb.enabled = false;
            Destroy(gameObject,2f);

            // Charge player lives
            Game.lives--;
        }
    }

}
