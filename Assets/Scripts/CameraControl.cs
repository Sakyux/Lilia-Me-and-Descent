using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public Camera cameraSize;
    private bool debugMode;

    void Start()
    {
        player = GameObject.Find("Lilia"); // Creates "Player" tag to reference to
        cameraSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        // Finds the position of Lilia
        float x = player.transform.position.x;
        float y = player.transform.position.y;

        // Changes position of the camera based off of Lilia
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);

        if (Input.GetKeyDown(KeyCode.R))
        {
            debugMode = !debugMode;
            if (debugMode) cameraSize.orthographicSize = 10;
            else cameraSize.orthographicSize = 5;
        }
    }
}
