using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    public Vector3 loadedPosition;
    public LockedDoor lockedDoor;
    public KeyItems keyItems;
    public void SaveGameData()
    {
        Debug.Log(Death.Instance.respawnPosition.x + " " + Death.Instance.respawnPosition.y + " " + Death.Instance.respawnPosition.z);
        Debug.Log(LockedDoor.Instance.open);
        for(int i = 0; i <= 7; i++) Debug.Log(KeyItems.Instance.slotsList[i].itemID);
        

        PlayerPrefs.SetFloat("PlayerPositionX", Death.Instance.respawnPosition.x);
        PlayerPrefs.SetFloat("PlayerPositionY", Death.Instance.respawnPosition.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", Death.Instance.respawnPosition.z);

        PlayerPrefs.SetInt("open", LockedDoor.Instance.open ? 1 : 0);

        PlayerPrefs.SetInt("slotsList", KeyItems.Instance.slotsList[1].itemID);

        PlayerPrefs.Save();
        Debug.Log("Game saved");
        Debug.Log(PlayerPrefs.GetInt("slotsList"));
        
    }

    public void LoadGameData()
    {
        float posX = PlayerPrefs.GetFloat("PlayerPositionX");
        float posY = PlayerPrefs.GetFloat("PlayerPositionY");
        float posZ = PlayerPrefs.GetFloat("PlayerPositionZ");
        Vector3 loadedPosition = new Vector3(posX, posY, posZ);

        lockedDoor.open = PlayerPrefs.GetInt("open") == 1;

        //int inventoryJson = PlayerPrefs.GetInt("slotsList");
        //List<SlotManager> loadedKeyItems = List<SlotManager>(inventoryJson);

        keyItems.slotsList[1].itemID = PlayerPrefs.GetInt("slotsList");
        
        Debug.Log(PlayerPrefs.GetFloat("PlayerPositionX") + " " + PlayerPrefs.GetFloat("PlayerPositionY") + " " + PlayerPrefs.GetFloat("PlayerPositionZ"));
        Debug.Log(PlayerPrefs.GetInt("open") == 1);
        Debug.Log(PlayerPrefs.GetInt("slotsList"));
        
        Debug.Log("GameLoaded");
    }
}
