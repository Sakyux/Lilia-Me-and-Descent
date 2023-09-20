using System.Collections;
using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class SaveData : MonoBehaviour
{
    public Vector3 loadedPosition;
    public void SaveGameData()
    {

        PlayerPrefs.SetFloat("PlayerPositionX", Death.Instance.respawnPosition.x);
        PlayerPrefs.SetFloat("PlayerPositionY", Death.Instance.respawnPosition.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", Death.Instance.respawnPosition.z);

        PlayerPrefs.SetInt("open", LockedDoor.Instance.open ? 1 : 0);

        string inventoryJson = JsonUtility.ToJson(KeyItems.Instance.slotsList);
        PlayerPrefs.SetString("slotsList", inventoryJson);

        PlayerPrefs.Save();
        Debug.Log("Game saved");
    }

    public void LoadGameData()
    {
        float posX = PlayerPrefs.GetFloat("PlayerPositionX");
        float posY = PlayerPrefs.GetFloat("PlayerPositionY");
        float posZ = PlayerPrefs.GetFloat("PlayerPositionZ");
        Vector3 loadedPosition = new Vector3(posX, posY, posZ);

        bool open = PlayerPrefs.GetInt("open") == 1;

        string inventoryJson = PlayerPrefs.GetString("slotsList");
        List<SlotManager> loadedKeyItems = JsonUtility.FromJson<List<SlotManager>>(inventoryJson);

        KeyItems.Instance.slotsList = loadedKeyItems;
        Debug.Log("GameLoaded");
    }
}
