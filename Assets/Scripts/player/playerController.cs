using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // Speed
    public float walkSpeed = 0.05f;
    public float sprintSpeed = 0.1f;
    public bool canSprint = true;
    
    // Private fields
    private Vector2 movement, newPosition;
    private bool isSprinting = false;
    private float currentSpeed;
    public static bool canMove = true;
    public bool isDead = false;

    // Gameplay
    public float stamina = 100f;
    public static float sanity = 100f;

    // Animation
    public Animator animator;

    // saving
    public static PlayerController Instance;

    void Start()
    {
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        // Checks position
        movement.x = Input.GetAxisRaw("Horizontal" + Options.controlOpt);
        movement.y = Input.GetAxisRaw("Vertical" + Options.controlOpt);

        // (FOR DEBUGGING)
        // Debug.Log("Stamina is at: " + stamina);
        
        // Disables sprint upon stamina depletion
        if (stamina >= 50 && Input.GetKeyDown(KeyCode.LeftShift)) canSprint = true;
        if (stamina <= 1) canSprint = false;
    }

    void FixedUpdate()
    {
        // Stamina
        if (Input.GetButton("Horizontal" + Options.controlOpt) || Input.GetButton("Vertical" + Options.controlOpt))
        {
            // Sprint function
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0f && canSprint)
            {
                currentSpeed = sprintSpeed; 
                stamina -= 0.5f; // Stamina depletion during sprint
                isSprinting = true;
            } else {
                currentSpeed = walkSpeed;
                isSprinting = false;    
            }
            
        } else isSprinting = false;

        if (stamina < 100 && isSprinting == false) stamina += 0.3f; // Normal stamina regen

        // Movement script
        if (canMove && !isDead)
        {
            newPosition = transform.position;
            newPosition.x += movement.x * currentSpeed;
            newPosition.y += movement.y * currentSpeed;

            // Horizontal movement
            if (Input.GetButton("Horizontal" + Options.controlOpt))
            {
                transform.position = newPosition;
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
            }

            // Vertical movement
            if (Input.GetButton("Vertical" + Options.controlOpt))
            {
                transform.position = newPosition;
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
            }
        }

        // Sets animator parameters
        if (canMove && !isDead)
        {
            animator.SetFloat("Speed", movement.sqrMagnitude);
            animator.SetBool("Sprint", isSprinting);
        }

        // TEMPORARY SANITY DEPLETION - FOR TESTING PURPOSES
        if (Input.GetKey(KeyCode.Q) && sanity >= 0f)
        {
            sanity -= 3f;
        }
        else if (sanity <= 100f)
        {
            sanity += 0.02f; // Sanity regeneration
        }

        // Prevents additive speed
        movement.Normalize();

        // Checks Death
        if (sanity <= 0) isDead = true;
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            
        }
    }
}
