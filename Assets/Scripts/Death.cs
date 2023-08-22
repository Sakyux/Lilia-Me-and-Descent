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
    public PlayerController playerRespawner;
    public float sanity;
    
    // Start is called before the first frame update
    void Start()
    {
        respawnButton.onClick.AddListener(respawn);
        
        isDead = false;
        deathScreen.SetActive(false);
        respawnPosition = player.transform.position;
        if (respawnPosition == player.transform.position) Debug.Log("yes");
    }

    // Update is called once per frame
    void Update()
    {
        sanity = playerRespawner.sanity;
        
        // kills the player after x seconds (Invoke thingy)
        if (sanity <= 0) Invoke("Kill", 0);
        
    }
    
    public void Kill() //I made this a function incase we want to add more Death sources e.g. instakills so dont remove it.
    {
        isDead = true;
        deathScreen.SetActive(true);
    }

    public void respawn()
    {
        isDead = false;
        deathScreen.SetActive(false);
        playerRespawner.sanity = 100;
        player.transform.position = respawnPosition;
    }

    // Respawn points   
    private void OnTriggerEnter2D(Collider2D other) // detects when respawn point is triggered
    {
        if (other.CompareTag("Respawn")) respawnPosition = other.transform.position;
    }

}
