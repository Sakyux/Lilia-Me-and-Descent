using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector3 respawnPosition;
    public Death Death;
    public GameObject CheckPoint;

    // Update is called once per frame
    void Update()
    {
        respawnPosition = Death.respawnPosition;
    }
    private void OnTriggerEnter2D(Collider2D other) // detects when respawn point is triggered
    {
        if (other.CompareTag("Player"))
        {
            respawnPosition = CheckPoint.transform.position;
            Death.respawnPosition = respawnPosition;
            

        }
    }

}
