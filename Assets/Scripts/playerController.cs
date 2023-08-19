using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float walkSpeed = 0.1f;
    public float sprintSpeed = 0.2f;
    public float stamina = 100f;
    public float sanity = 100f;

    public float movement;
    public Image sanityBar;
    
    void Start()
    {
        movement = walkSpeed;
    }

    void FixedUpdate()
    {
        sanityBar.fillAmount = (sanity / 100);
        
        

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0f)
            {
                movement = sprintSpeed;
                stamina -= 0.6f;
            } 
            else {
                movement = walkSpeed;
                if (stamina < 100f) stamina += 0.3f; // Slow stamina regen when movement is active
            }
        
        } else if (stamina < 100f) stamina += 0.6f; //Normal stamina regen

        
        if (stamina <= 1f) movement = 0.05f; // Slow movement speed when 0 stamina
        
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 newPosition = transform.position;
            newPosition.x -= movement;
            transform.position = newPosition;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 newPosition = transform.position;
            newPosition.x += movement;
            transform.position = newPosition;
        }

        if (Input.GetKey(KeyCode.W))
        {
            Vector2 newPosition = transform.position;
            newPosition.y += movement;
            transform.position = newPosition;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector2 newPosition = transform.position;
            newPosition.y -= movement;
            transform.position = newPosition;
        }
        
        //TEMPORARY
        if (Input.GetKey(KeyCode.Q) && sanity >= 0f)
        {
            sanity -= 1f;


        }
        else if (sanity <= 100f)
        {
            sanity += 0.02f;
        }

        

    }

    




}
