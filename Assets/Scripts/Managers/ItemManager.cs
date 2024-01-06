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
    public static ItemManager Instance;
    public List<ItemLister> itemList = new List<ItemLister>();

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
