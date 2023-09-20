using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // public Vector3 respawnPosition;
    public Death Death;
    public SaveData saveData;
    public GameObject CheckPoint;
    private bool savedHere = false;

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
            Death.respawnPosition = CheckPoint.transform.position;
            saveData.SaveGameData();
        }
    }

}
