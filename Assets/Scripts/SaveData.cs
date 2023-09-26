using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    public DoorManager doorManager;
    public KeyItems keyItems;
    public GameObject player;
    public ItemManager itemManager;
    public static SaveData Instance;

    private void Start()
    {
        if (Instance != null) LoadGameData();
        SaveGameData();
    }
    public void SaveGameData()
    {
        PlayerPrefs.SetFloat("PlayerPositionX", Checkpoint.Instance.respawnPosition.x);
        PlayerPrefs.SetFloat("PlayerPositionY", Checkpoint.Instance.respawnPosition.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", Checkpoint.Instance.respawnPosition.z);

        for (int i = 0; i <= DoorManager.Instance.DoorList.Count - 1; i++)
            PlayerPrefs.SetInt("Door_" + i, DoorManager.Instance.DoorList[i].isActive ? 1 : 0);

        for (int i = 0; i <= 7; i++)
            PlayerPrefs.SetInt("slotsList_" + i, KeyItems.Instance.slotsList[i].itemID);

        for (int i = 0; i <= ItemManager.Instance.itemList.Count - 1; i++)
            PlayerPrefs.SetInt("Item_" + i, ItemManager.Instance.itemList[i].isActive ? 1 : 0);

        PlayerPrefs.Save();
        Debug.Log("Game saved");

    }
    public void LoadGameData()
    {
        
        float posX = PlayerPrefs.GetFloat("PlayerPositionX");
        float posY = PlayerPrefs.GetFloat("PlayerPositionY");
        float posZ = PlayerPrefs.GetFloat("PlayerPositionZ");
        player.transform.position = new Vector3(posX, posY, posZ);

        for (int i = 0; i <= DoorManager.Instance.DoorList.Count - 1; i++)
            doorManager.DoorList[i].isActive = PlayerPrefs.GetInt("Door_" + i) == 1;

        for (int i = 0; i <= 7; i++) 
            keyItems.slotsList[i].itemID = PlayerPrefs.GetInt("slotsList_" + i);

        for (int i = 0; i <= ItemManager.Instance.itemList.Count - 1; i++)
            itemManager.itemList[i].isActive = PlayerPrefs.GetInt("Item_" + i) == 1;

        Debug.Log("Game Loaded");
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    }
