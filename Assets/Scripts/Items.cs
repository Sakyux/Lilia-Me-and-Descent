using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject item;
    public KeyItems keyItems;
    public int ItemID, itemNum;
    private bool playerNear = false, isActive = true;
    public ItemManager itemManager;
    void Update()
    {

        //if (isActive != check)
        //{
            
        //}

        if (playerNear && Input.GetKeyDown(KeyCode.Z))
        {
            isActive = false;
            itemManager.itemList[itemNum].isActive = isActive;
            item.SetActive(false);
            keyItems.AddItem(ItemID);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("trigger");
            playerNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
         if (other.CompareTag("Player")) playerNear = false;
    }
}
