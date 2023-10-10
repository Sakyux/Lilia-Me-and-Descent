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
    private bool collected = false;

    private void Start()
    {
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        keyItems = GameObject.Find("KeyItems").GetComponent<KeyItems>();
        item = GameObject.Find("Item" + itemNum + "GFX");
    }
    void Update()
    {
        if (itemManager.itemList[itemNum].isActive != check)
        {
            item.SetActive(itemManager.itemList[itemNum].isActive);
            check = itemManager.itemList[itemNum].isActive;
            Debug.Log("Changed Item State");
            if (itemManager.itemList[itemNum].isActive) collected = false;
        }

        if (!collected && playerNear && Input.GetKeyDown(KeyCode.Z))
        {
            itemManager.itemList[itemNum].isActive = false;
            keyItems.AddItem(ItemID);
            collected = true;
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
