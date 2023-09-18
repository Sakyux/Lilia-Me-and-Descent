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
    void Start()
    {
    slotsList[0].slot.Select();
    for (int i = 1; i<=7;i++) slotsList[i].slot.onClick.AddListener(() => SelectItem(i));
    }
    void Update()
    {
        
    }

    void SelectItem(int slotNum)
    {
        Debug.Log(slotNum);
    }
}
