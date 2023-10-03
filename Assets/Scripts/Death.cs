using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Death : MonoBehaviour
{
    public GameObject deathScreen;
    public PlayerController playerController;
    public static Death Instance;
    public SaveData saveData;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DisableDeathScreen", 0.01f);
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
        saveData.LoadGameData();
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void DisableDeathScreen()
    {
        deathScreen.SetActive(false);
    }
}
