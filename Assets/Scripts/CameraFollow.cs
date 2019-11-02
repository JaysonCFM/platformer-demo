using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private GameObject player;

    private Vector3 offset;
    
    
    void Start()
    {
        //Automatically finds the player in the scene.
        player = FindObjectOfType<Player>().gameObject;
        //Gets an offset so that the camera isn't directly on the player's coordinates.
        offset = transform.position - player.transform.position;
    }
    
    void LateUpdate()
    {
        //Move with the player.
        transform.position = player.transform.position + offset;
    }
}
