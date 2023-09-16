using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Creates "Player" tag to reference to
    }

    void Update()
    {
        // Finds the position of Lilia
        float x = player.transform.position.x;
        float y = player.transform.position.y;

        // Changes position of the camera based off of Lilia
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
