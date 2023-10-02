using UnityEngine;

[System.Serializable]
public class Checkpoint : MonoBehaviour
{
    private bool savedHere = false;

    public SaveData saveData;
    public Transform CheckPoint, enemyRespawnPoint, player;
    public static Checkpoint Instance;
    public static Vector3 respawnPosition;

    private void Start()
    {
        respawnPosition = player.position;
    }
    private void OnTriggerEnter2D(Collider2D other) // detects when respawn point is triggered
    {
        if (other.CompareTag("Player") && !savedHere)
        {
            savedHere = true;
            respawnPosition = CheckPoint.position;
            EnemyManager.spawnPositon = enemyRespawnPoint.position;
            saveData.SaveGameData();
        }
    }

    public void Awake()
    {
            Instance = this;
    }
}
