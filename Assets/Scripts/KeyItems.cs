using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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


    void Start()
    {
    slotsList[0].slot.Select();
        for (int i = 0; i <= 7; i++)
        {
            int buttonIndex = i;
            slotsList[i].slot.onClick.AddListener(() => SelectItem(buttonIndex));
        }
    }
    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.X))
        {
            MenuPanel.SetActive(true);
            menuStartButton.Select();
            KeyItemsMenu.SetActive(false);
        }
    }
    void SelectItem(int slotNum)
    {
        if (heldItem != slotsList[slotNum].itemID)
        {
            heldItem = slotsList[slotNum].itemID;
            menu.ToggleMenu();
            KeyItemsMenu.SetActive(false);
            Debug.Log("item selected");
        }
        else
        {
            heldItem = 0;
            Debug.Log("item deselected");
        }
        
    }
    public void AddItem(int addedItemID)
    {
        bool itemPlaced = false;
        for (int i = 0; i <= 7; i++)
        {
            if (!itemPlaced && slotsList[i].itemID == 0)
            {
                slotsList[i].itemID = addedItemID;
                slotsList[i].slotSprite.sprite = spriteList[slotsList[i].itemID].itemSprite;
                itemPlaced = true;
            }
        }
    }
    public void UseItem(int usedItemID) // clears all items in inventory sharing the id of the used item. this means each item can only occur once.
    {
        for (int i = 0; i <= 7; i++)
        {
            if (slotsList[i].itemID == usedItemID)
            {
                slotsList[i].itemID = 0;
                slotsList[i].slotSprite.sprite = spriteList[0].itemSprite;
            }
            heldItem = 0;
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
