using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    public DoorManager doorManager;
    public KeyItems keyItems;
    public GameObject player, Enemy;
    public ItemManager itemManager;
    public static SaveData Instance;
    public static bool load;
     
    private void Start()
    {
        if (load == true) LoadGameData();
        SaveGameData();
    }
    public void SaveGameData()
    {
        // game
        PlayerPrefs.SetFloat("PlayerPositionX", Checkpoint.respawnPosition.x);
        PlayerPrefs.SetFloat("PlayerPositionY", Checkpoint.respawnPosition.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", Checkpoint.respawnPosition.z);

        for (int i = 0; i <= DoorManager.Instance.DoorList.Count - 1; i++)
            PlayerPrefs.SetInt("Door_" + i, DoorManager.Instance.DoorList[i].isActive ? 1 : 0);

        for (int i = 0; i <= 7; i++)
            PlayerPrefs.SetInt("slotsList_" + i, KeyItems.Instance.slotsList[i].itemID);

        for (int i = 0; i <= ItemManager.Instance.itemList.Count - 1; i++)
            PlayerPrefs.SetInt("Item_" + i, ItemManager.Instance.itemList[i].isActive ? 1 : 0);

        // options 
        PlayerPrefs.SetFloat("Volume", Options.volumeLevel);
        PlayerPrefs.SetInt("Resolution", Options.resolutionIndex);

        PlayerPrefs.Save();
        Debug.Log("Game saved");

    }
    public static void LoadOptionsData()
    {
        Options.volumeLevel = PlayerPrefs.GetFloat("Volume");
        Options.resolutionIndex = PlayerPrefs.GetInt("Resolution");
    }
    public void LoadGameData()
    {
        // game
        float posX = PlayerPrefs.GetFloat("PlayerPositionX");
        float posY = PlayerPrefs.GetFloat("PlayerPositionY");
        float posZ = PlayerPrefs.GetFloat("PlayerPositionZ");
        player.transform.position = new Vector3(posX, posY, posZ);

        for (int i = 0; i <= doorManager.DoorList.Count - 1; i++)
            doorManager.DoorList[i].isActive = PlayerPrefs.GetInt("Door_" + i) == 1;

        for (int i = 0; i <= 7; i++) 
            keyItems.slotsList[i].itemID = PlayerPrefs.GetInt("slotsList_" + i);

        keyItems.heldItem = 0;

        for (int i = 0; i <= ItemManager.Instance.itemList.Count - 1; i++)
            itemManager.itemList[i].isActive = PlayerPrefs.GetInt("Item_" + i) == 1;

        Enemy.transform.position = EnemyManager.spawnPositon;

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
