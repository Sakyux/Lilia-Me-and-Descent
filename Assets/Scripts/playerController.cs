using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // movement speeds
    public float walkSpeed = 0.1f;
    public float sprintSpeed = 0.2f;
    public float movement;

    // stamina
    public float stamina = 100f;
    public Image StaminaBarLeft, StaminaBarRight;
    public float currentBarOpacity;
    public float targetOpacity = 0f;
    
    // sanity
    public float sanity = 100f;
    public Image sanityBarBackGround;
    public Image sanityBar;
    public bool isDead = true;
    
    
    void Start()
    {
        movement = walkSpeed;
    }

    void FixedUpdate()
    {
        // Stamina

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0f)
            {
                movement = sprintSpeed; 
                stamina -= 0.6f; // stamina depletion during sprint
            } 
            else {
                movement = walkSpeed;
                if (stamina < 100f) stamina += 0.3f; // Slow stamina regen when movement is active
            }
        
        } else if (stamina < 100f) stamina += 0.6f; //Normal stamina regen

        if (stamina <= 1f) movement = 0.05f; // Slow movement speed when 0 stamina

        // stamina bar(s) fill amount based on stamina
        StaminaBarLeft.fillAmount = (stamina / 100 - 0.01f);
        StaminaBarRight.fillAmount = (stamina / 100 - 0.01f);

        // bar fading in and out
        currentBarOpacity = StaminaBarLeft.color.a;
        if (stamina >= 100f) targetOpacity = 0;
        else targetOpacity = 1;
        if (currentBarOpacity != targetOpacity)
        {
            float step = Time.deltaTime * 2;
            currentBarOpacity = Mathf.MoveTowards(currentBarOpacity, targetOpacity, step);

            Color barColour = StaminaBarLeft.color;
            barColour.a = currentBarOpacity;
            StaminaBarLeft.color = barColour;
            StaminaBarRight.color = barColour;
        }

        // Movement
        
            // left
            if (Input.GetKey(KeyCode.A))
            {
                Vector2 newPosition = transform.position;
                newPosition.x -= movement;
                transform.position = newPosition;
            }
            // right
            if (Input.GetKey(KeyCode.D))
            {
                Vector2 newPosition = transform.position;
                newPosition.x += movement;
                transform.position = newPosition;
            }
            // up
            if (Input.GetKey(KeyCode.W))
            {
                Vector2 newPosition = transform.position;
                newPosition.y += movement;
                transform.position = newPosition;
            }
            // down
            if (Input.GetKey(KeyCode.S))
            {
                Vector2 newPosition = transform.position;
                newPosition.y -= movement;
                transform.position = newPosition;
            }
        
        // sanity

        //TEMPORARY SANITY DEPLETION - FOR TESTING PURPOSES
        if (Input.GetKey(KeyCode.Q) && sanity >= 0f)
        {
            sanity -= 1f;
        }
        else if (sanity <= 100f)
        {
            sanity += 0.02f; // sanity regen
        }

        sanityBar.fillAmount = (sanity / 100);

        // death
        if (sanity <= 0) isDead = true;

        if (isDead == true)
        {
            sanityBar.enabled = false;
            sanityBarBackGround.enabled = false;
            StaminaBarLeft.enabled = false;
            StaminaBarRight.enabled = false;
        } else
        {
            sanityBar.enabled = true;
            sanityBarBackGround.enabled = true;
            StaminaBarLeft.enabled = true;
            StaminaBarRight.enabled = true;
        }
    }
}