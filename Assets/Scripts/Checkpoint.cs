using UnityEngine;

[System.Serializable]
public class Checkpoint : MonoBehaviour
{
    // public Vector3 respawnPosition;
    public SaveData saveData;
    public GameObject CheckPoint;
    private bool savedHere = false;
    public static Checkpoint Instance;
    public static Vector3 respawnPosition;
    public GameObject player;

    private void Start()
    {
        respawnPosition = player.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        // respawnPosition = Death.respawnPosition;
    }
    private void OnTriggerEnter2D(Collider2D other) // detects when respawn point is triggered
    {
        if (other.CompareTag("Player") && !savedHere)
        {
            savedHere = true;
            respawnPosition = CheckPoint.transform.position;
            saveData.SaveGameData();
        }
    }

    public void Awake()
    {
            Instance = this;
    }
}
