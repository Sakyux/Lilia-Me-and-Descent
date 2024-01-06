using UnityEngine;

[System.Serializable]
public class Checkpoint : MonoBehaviour
{
    private bool savedHere = false;

    public SaveData saveData;
    public Transform enemyRespawnPoint, player;
    public static Checkpoint Instance;
    public static Vector3 respawnPosition;

    private void Start()
    {
        saveData = GameObject.Find("SaveGame").GetComponent<SaveData>(); 
        enemyRespawnPoint = transform.GetChild(0).gameObject.transform;
        player = GameObject.Find("Lilia").GetComponent<Transform>();   
        respawnPosition = player.position;
    }
    private void OnTriggerEnter2D(Collider2D other) // detects when respawn point is triggered
    {
        if (other.CompareTag("Player") && !savedHere)
        {
            savedHere = true;
            respawnPosition = transform.position;
            EnemyManager.spawnPositon = enemyRespawnPoint.position;
            saveData.SaveGameData();
        }
    }

    public void Awake()
    {
            Instance = this;
    }
}
