using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SlotManager
{
    public Button slot;
    public string item;
}
public class KeyItems : MonoBehaviour
    {
    public SlotManager slotManager;
    public List<SlotManager> slotsList = new List<SlotManager>();
    private string heldItem = null;
    void Start()
    {
    slotsList[0].slot.Select();
        for (int i = 0; i <= 7; i++)
        {
            int buttonIndex = i;
            slotsList[i].slot.onClick.AddListener(() => SelectItem(buttonIndex));
        }
    }
    void Update()
    {
        
    }

    void SelectItem(int slotNum)
    {
        heldItem = slotsList[slotNum].item;
        slotsList[slotNum].slot.onClick.AddListener(Deselect);
    }
    void Deselect()
    {
        heldItem = null;
    }
}
