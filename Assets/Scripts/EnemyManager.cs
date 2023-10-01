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

    void Wander()
    {
        playerLocator.position = new Vector3((float)Random.Range(-10, 10), (float)Random.Range(-10, 10), 10f);
        AIPath.maxSpeed = 2;
    }
}
