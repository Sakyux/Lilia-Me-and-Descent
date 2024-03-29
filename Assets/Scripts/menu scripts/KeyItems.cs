﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SlotManager
{
    public Image slotSprite;
    public Button slot; 
    public int itemID;
}
[System.Serializable]
public class SpriteManager
{
    public Sprite itemSprite;
}
[System.Serializable]
public class KeyItems : MonoBehaviour
{
    public List<SlotManager> slotsList = new List<SlotManager>();
    public List<SpriteManager> spriteList = new List<SpriteManager>();
    public int heldItem = 0;
    public GameObject KeyItemsMenu, MenuPanel;
    public Menu menu;
    public Button menuStartButton;
    public static KeyItems Instance;
    public GameLog gameLog; 
    

    void Start()
    {
        MenuPanel = GameObject.Find("MenuPanel");
        menu = GameObject.Find("Menu").GetComponent<Menu>();
        menuStartButton = GameObject.Find("KeyItemsButton").GetComponent<Button>();
        KeyItemsMenu = GameObject.Find("KeyItems");
        gameLog = GameObject.Find("GameLog").GetComponent<GameLog>();


        slotsList[0].slot.Select();
        for (int i = 0; i <= 7; i++)
        {
            int buttonIndex = i;
            slotsList[i].slot.onClick.AddListener(() => SelectItem(buttonIndex));
        }

        Invoke("DisableKeyItems", 0.01f);
    }
    private void Update()
    { 
        if (Input.GetButtonDown("menu" + Options.controlOpt))
        {
            MenuPanel.SetActive(true);
            menuStartButton.Select();
            KeyItemsMenu.SetActive(false);
        }
    }
    void SelectItem(int slotNum)
    {
        if (heldItem != -1) if (heldItem != slotsList[slotNum].itemID)
        {
            heldItem = slotsList[slotNum].itemID;
            menu.ToggleMenu();
            KeyItemsMenu.SetActive(false);
            Invoke("DeselectItem", 0.01f);
        }
        else
        {
            heldItem = 0;
        }
        
    }
    public void AddItem(int addedItemID)
    {
        bool itemPlaced = false;
        for (int i = 0; i <= 7; i++)
        {
            if (!itemPlaced && slotsList[i].itemID == 0)
            {
                if (i == 1) Debug.Log(addedItemID);
                slotsList[i].itemID = addedItemID;
                itemPlaced = true;
            }
        }

        ReloadKeyItems();
    }
    public void UseItem(int usedItemID) // clears all items in inventory sharing the id of the used item. this means each item can only occur once.
    {
        for (int i = 0; i <= 7; i++)
        {
            if (slotsList[i].itemID == usedItemID)
            {
                slotsList[i].itemID = 0; // *
                slotsList[i].slotSprite.sprite = spriteList[0].itemSprite;
            }
            heldItem = 0;
        }
        gameLog.AddEvent("Item Used.");
    }

    public void ReloadKeyItems()
    {
        for (int i = 0; i <= 7; i++)
        {
            slotsList[i].slotSprite.sprite = spriteList[slotsList[i].itemID].itemSprite;
            if (slotsList[i].itemID == 0) slotsList[i].slotSprite.color = new Color(1, 1, 1, 0);
            else slotsList[i].slotSprite.color = new Color(1, 1, 1, 1);
        }
    }

    void DeselectItem()
    {
        heldItem = 0;
    }

    void DisableKeyItems()
    {
        gameObject.SetActive(false);
        PlayerController.canMove = true;
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
