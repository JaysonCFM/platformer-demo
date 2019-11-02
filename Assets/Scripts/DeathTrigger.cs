using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    private Scene scene;
    
    void Start()
    {
        //Gets the current scene name
        scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            //Current functionality is that the player will reset the entire scene.
            SceneManager.LoadScene(scene.name);
        }
    }
}
