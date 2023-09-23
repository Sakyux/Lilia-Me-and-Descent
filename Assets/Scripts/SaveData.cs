using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    public LockedDoor lockedDoor;
    public KeyItems keyItems;
    public GameObject player;

    private void Start()
    {
        SaveGameData();
    }
    public void SaveGameData()
    {
        //Debug.Log(Death.Instance.respawnPosition.x + " " + Death.Instance.respawnPosition.y + " " + Death.Instance.respawnPosition.z);
        //Debug.Log(LockedDoor.Instance.open);
        //for(int i = 0; i <= 7; i++) 
        //    Debug.Log(KeyItems.Instance.slotsList[i].itemID);

        PlayerPrefs.SetInt("testValue", 5);

        PlayerPrefs.SetFloat("PlayerPositionX", Checkpoint.Instance.respawnPosition.x);
        PlayerPrefs.SetFloat("PlayerPositionY", Checkpoint.Instance.respawnPosition.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", Checkpoint.Instance.respawnPosition.z);

        PlayerPrefs.SetInt("open", LockedDoor.Instance.open ? 1 : 0);

        for (int i = 0; i <= 7; i++)
        PlayerPrefs.SetInt("slotsList_" + i, KeyItems.Instance.slotsList[i].itemID);

        PlayerPrefs.Save();
        Debug.Log("Game saved");

    }
    public void LoadGameData()
    {
        float posX = PlayerPrefs.GetFloat("PlayerPositionX");
        float posY = PlayerPrefs.GetFloat("PlayerPositionY");
        float posZ = PlayerPrefs.GetFloat("PlayerPositionZ");
        player.transform.position = new Vector3(posX, posY, posZ);

        lockedDoor.open = PlayerPrefs.GetInt("open") == 1;

        for (int i = 0; i <= 7; i++) keyItems.slotsList[i].itemID = PlayerPrefs.GetInt("slotsList_" + i);
        
        Debug.Log("Game Loaded");
    }
}
