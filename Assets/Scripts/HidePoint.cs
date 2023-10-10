using UnityEngine;

public class HidePoint : MonoBehaviour
{
    private bool playerNear;
    private bool playerHiding;
    public LayerMask playerLayer;
    private int rayHitIndex = -1;
    public GameObject hidePoint, player, hidePrompt;
    public Vector3 hideSpot;
    public Vector3 playerLeaveSpot;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Lilia").GetComponent<PlayerController>();
        hidePoint = GameObject.Find("HidePoint");
        player = GameObject.Find("Lilia");
        hidePrompt = GameObject.Find("HidePointPrompt");

        hideSpot = hidePoint.transform.position;
        Invoke("Disable", 0.01f);
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

        if (playerHiding && Input.GetKeyDown(KeyCode.Z) && playerController.canMove)
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

        if (!playerHiding && playerNear && playerController.canMove)
        {
            hidePrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                playerHiding = true;
                player.transform.position = hideSpot;
                Debug.Log(player.transform.position);
            }
        } 
        else
        {
            hidePrompt.SetActive(false);
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

    void Disable()
    {
        hidePrompt.SetActive(false);
    }
}
