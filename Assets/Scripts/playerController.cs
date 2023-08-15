using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 0.1f;
    public float stamina = 100f;
    public float sanity = 100f;
    void Start()
    {

    }

    // Update is called once per frame.
    void FixedUpdate()
    {

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


        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 newPosition = transform.position;
            newPosition.x += moveSpeed;
            transform.position = newPosition;


        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 newPosition = transform.position;
            newPosition.y += moveSpeed;
            transform.position = newPosition;

        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector2 newPosition = transform.position;
            newPosition.y -= moveSpeed;
            transform.position = newPosition;

        }
        //TEMPORARY
        if (Input.GetKey(KeyCode.Q) && sanity >= 20f)
        {
            sanity -= 1f;


        }
        else if (sanity <= 100f)
        {
            sanity += 0.02f;
        }

    }






}
