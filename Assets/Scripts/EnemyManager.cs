using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Vector2 direction;
    private bool playerSeen = false, lurking = false, charging = false;
    private float distance;
    public LayerMask playerLayer;
    public AIDestinationSetter destinationSetter;
    public Transform player, playerLocator;
    public AIPath AIPath;

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
        distance = Vector2.Distance(transform.position, playerLocator.position);
        direction = player.position - transform.position;
        direction.Normalize();
        CastRay(direction);

        if (distance <=2.5f)
        {
            PlayerController.sanity -= (2.5f - Vector2.Distance(transform.position, player.position)) / 50;
        }

        if (playerSeen)
        {
            if (!lurking) Invoke("Charge", 3);
            Detect();
            if (lurking) AIPath.maxSpeed = 1f;
        }

        // Checks if the enemy has reached the last seen location of the player
        if (!playerSeen && distance <= 2)
        {
            Wander();
        }

        if (playerSeen &&  distance <= 4) Charge();
        // Button is a placeholder for anything that might alert the monster of the players position.
        if (Input.GetKeyDown(KeyCode.E)) Detect();
    }

    private void CastRay(Vector2 direction)
    {
        RaycastHit2D seePlayer = Physics2D.Raycast(transform.position, direction, 100f, playerLayer);

        if (seePlayer.collider != null && seePlayer.collider.CompareTag("Player"))
        {
            if (!HidePoint.playerHiding) playerSeen = true;
            else playerSeen = false;
        }
        else
        {
            if (!lurking) playerSeen = false;
        }
    }

    //Commented out for testing purposes, makes the enemy kill the player on contact.
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
        AIPath.maxSpeed = 2.5f;
        charging = false;
    }

    void Detect()
    {
        playerLocator.position = player.position;
        if (!charging) lurking = true;
    }

    void Charge()
    {
        if (playerSeen)
        {
            Detect();
            AIPath.maxSpeed = 6.5f;
            lurking = false;
            charging = true;
            Invoke("Wander", 3);
        }
        
    }
}
