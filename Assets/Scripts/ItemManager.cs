using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemLister
{
    public bool isActive = true;
}

[System.Serializable]
public class ItemManager : MonoBehaviour
{
    public List<ItemLister> itemList = new List<ItemLister>();
}
