using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoor : MonoBehaviour
{
    public Collider2D Collider2D;
    public KeyItems keyItems;
    public Sprite unlockedSprite;
    public Image Door;
    public int requiredKeyID;
    private bool playerNear;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.Z))
        {
            if (keyItems.heldItem == requiredKeyID) UnlockDoor();
            else if (keyItems.heldItem != 0) Debug.Log("incorrect item");
        }
    }

    private void UnlockDoor()
    {
        Collider2D.isTrigger = true;
        Door.sprite = unlockedSprite;
        keyItems.heldItem = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
}
