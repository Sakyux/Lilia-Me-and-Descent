using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePoint : MonoBehaviour
{
    public bool playerNear;
    public bool playerHiding;
    public LayerMask playerLayer;
    public int rayHitIndex = -1;
    public GameObject hidePoint;
    public GameObject player;
    public Vector3 hideSpot;
    public Vector3 playerLeaveSpot;
    // Start is called before the first frame update
    void Start()
    {
        hideSpot = hidePoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerNear = false;

        if (!playerHiding)
        {
            CastRay(Vector2.up, 0);
            CastRay(Vector2.down, 1);
            CastRay(Vector2.left, 2);
            CastRay(Vector2.right, 3);
        }

        if (playerHiding && Input.GetKeyDown(KeyCode.Z))
        {
            playerHiding = false;
            playerLeaveSpot = hideSpot;
            switch (rayHitIndex)
            {
                case 0:
                    playerLeaveSpot.y = hideSpot.y + 1;
                    break;
                case 1:
                    playerLeaveSpot.y = hideSpot.y - 1;
                    break;
                case 2:
                    playerLeaveSpot.x = hideSpot.x - 1;
                    break;
                case 3:
                    playerLeaveSpot.x = hideSpot.x + 1;
                    break;
            }
            player.transform.position = playerLeaveSpot;
        }

        if (!playerHiding && playerNear && Input.GetKeyDown(KeyCode.Z))
        {
            playerHiding = true;
            player.transform.position = hideSpot;
            Debug.Log(player.transform.position);
        }
    }
    private void CastRay(Vector2 direction, int rayIndex)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, playerLayer);

        if (hit.collider != null && hit.collider.CompareTag("Player")) 
        {
            rayHitIndex = rayIndex;
            playerNear = true;
        }
    }
}
