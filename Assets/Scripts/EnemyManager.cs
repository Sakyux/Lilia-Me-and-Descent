using Pathfinding;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Vector2 direction;
    private bool playerSeen = false;

    public LayerMask playerLayer;
    public AIDestinationSetter destinationSetter;
    public Transform player, playerLocator;
    public AIPath AIPath;
    public static Vector2 spawnPositon = new Vector3(0, 0, 0);
    void Update()
    {
        direction = player.position - transform.position;
        direction.Normalize();
        CastRay(direction);


        // Checks if the enemy has reached the last seen location of the player
        if (!playerSeen && Vector2.Distance(transform.position, playerLocator.position) <= 2)
        {
            Wander();
        }

        // Button is a placeholder for anything that might alert the monster of the players position.
        if (Input.GetKeyDown(KeyCode.E)) Detect();
    }

    private void CastRay(Vector2 direction)
    {
        RaycastHit2D seePlayer = Physics2D.Raycast(transform.position, direction, 100f, playerLayer);

        if (seePlayer.collider != null && seePlayer.collider.CompareTag("Player"))
        {
            playerSeen = true;
            playerLocator.position = player.position;
            AIPath.maxSpeed = 4;
        }
        else
        {
            playerSeen = false;
        }
    }

    // Commented out for testing purposes, makes the enemy kill the player on contact
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Death.Instance.Kill();
    //    }
    //}
    void Wander()
    {
        playerLocator.position = new Vector3((float)Random.Range(-10, 10), (float)Random.Range(-10, 10), 10f);
        AIPath.maxSpeed = 2;
    }

    void Detect()
    {
        playerLocator.position = player.position;
    }
}