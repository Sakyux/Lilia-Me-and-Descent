using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class LockedDoor : MonoBehaviour
{
    public Collider2D Collider2D;
    public KeyItems keyItems;
    public Sprite unlockedSprite, lockedSprite;
    public SpriteRenderer Door;
    public int requiredKeyID;
    private bool playerNear;
    public bool open = false;
    public static LockedDoor Instance;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.Z))
        {
            if (keyItems.heldItem == requiredKeyID && !open) open = true;
            else if (keyItems.heldItem != 0 && !open) Debug.Log("incorrect item");
        }

        if (open) UnlockDoor();
        else LockDoor();
    }

    private void UnlockDoor()
    {
        Collider2D.isTrigger = true;
        Door.sprite = unlockedSprite;
        keyItems.UseItem(keyItems.heldItem);
    }

    private void LockDoor()
    {
        Collider2D.isTrigger = false;
        Door.sprite = lockedSprite;
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
}
