using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject player;
    public Vector3 respawnPosition;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        deathScreen.SetActive(false);
        respawnPosition = player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        // kills the player after x seconds (Invoke thingy)
        if (playerController.isDead) Invoke("Kill", 0);
        
    }
    
    public void Kill() //I made this a function incase we want to add more Death sources e.g. instakills so dont remove it.
    {
        playerController.isDead = true;
        deathScreen.SetActive(true);
        Invoke("respawn", 0);
    }

    public void respawn()
    {
        playerController.isDead = false;
        deathScreen.SetActive(false);
        playerController.sanity = 100;
        player.transform.position = respawnPosition;
    }

}
