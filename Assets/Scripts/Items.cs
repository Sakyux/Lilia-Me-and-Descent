using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject item;
    public KeyItems keyItems;
    public int ItemID, itemNum;
    private bool playerNear = false, check = true;
    public ItemManager itemManager;
    void Update()
    {
        // WIP
        if (itemManager.itemList[itemNum].isActive != check)
        {
            item.SetActive(itemManager.itemList[itemNum].isActive);
            check = itemManager.itemList[itemNum].isActive;
            Debug.Log("Changed Item State");
        }

        if (playerNear && Input.GetKeyDown(KeyCode.Z))
        {
            itemManager.itemList[itemNum].isActive = false;
            keyItems.AddItem(ItemID);
        }
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
         if (other.CompareTag("Player")) playerNear = false;
    }
}
