using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 0.1f;
    public float stamina = 100f;
    public float sanity = 100f;

    public Scrollbar sanityBar;

    public SpriteRenderer LiliaSprite;
    public Sprite DownIdle, UpIdle, LeftIdle, RightIdle;
    short HorizontalMovement = 0;
    
    
    
    void Start()
    {
        LiliaSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame.
    void FixedUpdate()
    {

        sanityBar.size = (sanity / 100);
        
        

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0f)
            {
                moveSpeed = 0.2f;
                stamina -= 0.5f;
            }
            else
            {
                moveSpeed = 0.1f;
                if (stamina < 100f)
                {
                    stamina += 0.3f;
                }
            }
        }
        else
        {

            if (stamina < 100f)
            {
                stamina += 1f;
            }
        }
        if (stamina <= 1f)
        {
            moveSpeed = 0.05f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 newPosition = transform.position;
            newPosition.x -= moveSpeed;
            transform.position = newPosition;
            LiliaSprite.sprite = LeftIdle;
            

        }
        

        if (Input.GetKey(KeyCode.D))
        {
            Vector2 newPosition = transform.position;
            newPosition.x += moveSpeed;
            transform.position = newPosition;
            LiliaSprite.sprite = RightIdle;

        }

        if (Input.GetKey(KeyCode.W))
        {
            Vector2 newPosition = transform.position;
            newPosition.y += moveSpeed;
            transform.position = newPosition;
            LiliaSprite.sprite = UpIdle;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector2 newPosition = transform.position;
            newPosition.y -= moveSpeed;
            transform.position = newPosition;
            LiliaSprite.sprite = DownIdle;
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
