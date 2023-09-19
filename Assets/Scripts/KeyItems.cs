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
public class KeyItems : MonoBehaviour
{
    public List<SlotManager> slotsList = new List<SlotManager>();
    public List<SpriteManager> spriteList = new List<SpriteManager>();
    public int heldItem = 0;
    public GameObject KeyItemsMenu, MenuPanel;
    public Menu menu;
    public Button menuStartButton;
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
        heldItem = slotsList[slotNum].itemID;
        slotsList[slotNum].itemID = 0;
        slotsList[slotNum].slot.onClick.AddListener(DeselectItem);

        menu.ToggleMenu();
        KeyItemsMenu.SetActive(false);

    }
    void DeselectItem()
    {
        AddItem(heldItem);
        heldItem = 0;
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
}
