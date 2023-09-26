using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DoorLister
{
    public bool isActive = true;
}

[System.Serializable]
public class DoorManager : MonoBehaviour
{
    public static DoorManager Instance;
    public List<ItemLister> DoorList = new List<ItemLister>();

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
