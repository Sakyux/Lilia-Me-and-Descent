using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Speed
    public float walkSpeed = 0.1f;
    public float sprintSpeed = 0.2f;
    
    // Private fields
    private Vector2 movement, newPosition;
    private bool isSprinting = false;
    private float currentSpeed;
    public bool canMove = true;
    public bool isDead = false;

    // Gameplay
    public float stamina = 100f;
    public float sanity = 100f;

    // Animation
    public Animator animator;

    void Start()
    {
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        // Checks position
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Prevents additive speed
        movement.Normalize();

        // (FOR DEBUGGING)
        Debug.Log("Stamina is at: " + stamina);
    }

    void FixedUpdate()
    {
        // Stamina
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            // Sprint function
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0f)
            {
                currentSpeed = sprintSpeed; 
                stamina -= 0.5f; // Stamina depletion during sprint
                isSprinting = true;
            } else {
                currentSpeed = walkSpeed;
                isSprinting = false;    
            }   

            if (stamina <= 0) { // Disables sprint upon stamina depletion
                    if (stamina <= 50 && Input.GetKeyDown(KeyCode.LeftShift)) {
                        isSprinting = false;
                        currentSpeed = walkSpeed;
                    }
                }
        
        } else isSprinting = false;

        if (stamina < 100 && isSprinting == false) stamina += 0.5f; // Normal stamina regen

        // Movement script
        if (canMove && !isDead)
        {
            newPosition = transform.position;
            newPosition.x += movement.x * currentSpeed;
            newPosition.y += movement.y * currentSpeed;

            // Left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movement.x -= 1;
                transform.position = newPosition;
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
            }
            // Right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                movement.x += 1;
                transform.position = newPosition;
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
            }
            // Up
            if (Input.GetKey(KeyCode.UpArrow))
            {
                movement.y += 1;
                transform.position = newPosition;
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
            }
            // Down
            if (Input.GetKey(KeyCode.DownArrow))
            {
                movement.y -= 1;
                transform.position = newPosition;
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
            }
        }

        // Sets animator parameters
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("Sprint", isSprinting);

        // TEMPORARY SANITY DEPLETION - FOR TESTING PURPOSES
        if (Input.GetKey(KeyCode.Q) && sanity >= 0f)
        {
            sanity -= 1f;
        }
        else if (sanity <= 100f)
        {
            sanity += 0.02f; // Sanity regeneration
        }

        // Checks Death
        if (sanity <= 0) isDead = true;
    }
}
