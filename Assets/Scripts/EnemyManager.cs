using Pathfinding;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Vector2 direction;
    
    private float distance, distanceToLocator;
    public LayerMask playerLayer;
    public AIDestinationSetter destinationSetter;
    public Transform player, playerLocator;
    public AIPath AIPath;
    private bool playerSeen = false;
    
    // public for testing
    public bool wander, chase; //temp
    public bool lurking, charging; //necessary

    public static Vector3 spawnPositon = new Vector3(0, 0, 0);
    private void Start()
    {
        destinationSetter = GameObject.Find("Enemy").GetComponent<AIDestinationSetter>();
        AIPath = GameObject.Find("Enemy").GetComponent<AIPath>();
        player = GameObject.Find("Lilia").GetComponent<Transform>();
        playerLocator = GameObject.Find("PlayerLocator").GetComponent<Transform>();
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        distanceToLocator = Vector2.Distance(transform.position, playerLocator.position);
        direction = player.position - transform.position;
        direction.Normalize();
        CastRay(direction);

        if (!playerSeen) Wander();
        if (playerSeen && distance <= 4 && !charging) Chase();
        if (playerSeen && distance > 4 && !charging && !lurking) Lurk();

        // Button is a placeholder for anything that might alert the monster of the players position.
        if (Input.GetKeyDown(KeyCode.E)) Detect();

        if(distance <= 2) PlayerController.sanity -= 2 - distance/5;
    }

    private void CastRay(Vector2 direction)
    {
        RaycastHit2D seePlayer = Physics2D.Raycast(transform.position, direction, 100f, playerLayer);

        if (seePlayer.collider != null && seePlayer.collider.CompareTag("Player") && !HidePoint.playerHiding)
        {
            playerSeen = true;
            Detect();
        }
        else
        {
            playerSeen = false;
        }
    }

    //Commented out for testing purposes, makes the enemy kill the player on contact.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) Death.Instance.Kill();
    }

    void Wander()
    {
        if (distanceToLocator <= 2) playerLocator.position = new Vector3((float)Random.Range(-10, 10), (float)Random.Range(-10, 10), 10f);
        AIPath.maxSpeed = 2.5f;
        charging = false;
        chase = false;
        lurking = false;
        wander = true;
    }

    void Detect()
    {
        playerLocator.position = player.position;
    }

    void Charge()
    {
        AIPath.maxSpeed = 6.5f;
        lurking = false;
        charging = true;
        chase = false;
        wander = false;
        Invoke("Chase", 3);
    }

    void Chase()
    {
        AIPath.maxSpeed = 5f;
        lurking = false;
        charging = false;
        chase = true;
        wander = false;

    }
    void Lurk()
    {
        AIPath.maxSpeed = 1f;
        lurking = true;
        charging = false;
        chase = false;
        wander = false;
        Invoke("Charge", 3);

    }
}
