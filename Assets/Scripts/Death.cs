using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject player;
    public Button respawnButton;
    public bool isDead;
    public Vector3 respawnPosition;
    public PlayerController playerController;
    public float sanity;
    

    // Start is called before the first frame update
    void Start()
    {
        respawnButton.onClick.AddListener(respawn);
        
        deathScreen.SetActive(false);
        respawnPosition = player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        sanity = playerController.sanity;
        isDead = playerController.isDead;
        // kills the player after x seconds (Invoke thingy)
        if (isDead == true) Invoke("Kill", 0);
        
    }
    
    public void Kill() //I made this a function incase we want to add more Death sources e.g. instakills so dont remove it.
    {
        playerController.isDead = true;
        deathScreen.SetActive(true);
        respawnButton.Select();
    }

    public void respawn()
    {
        playerController.isDead = false;
        deathScreen.SetActive(false);
        playerController.sanity = 100;
        player.transform.position = respawnPosition;
    }

}
