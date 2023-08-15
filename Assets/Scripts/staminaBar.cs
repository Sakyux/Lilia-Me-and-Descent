using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class staminaBar : MonoBehaviour
{
    public GameObject firstObject;
    private float barLength;


    private SpriteRenderer spriteRenderer;
    private float currentOpacity;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        playerController playerControllerReference = firstObject.GetComponent<playerController>();
        float stamina = playerControllerReference.stamina;
        barLength = stamina / 10;
        Vector2 newLength = transform.localScale;
        newLength.x = barLength;
        transform.localScale = newLength;



        if (barLength < 10f)
        {
            fadeInObject();
        }
        else
        {
            fadeOutObject();
        }
        currentOpacity = spriteRenderer.color.a;
    }

    public void fadeOutObject()
    {
        if (currentOpacity != 0f)
        {
            float step = Time.deltaTime * 2;
            currentOpacity = Mathf.MoveTowards(currentOpacity, 0f, step);

            Color barOpacity = spriteRenderer.color;
            barOpacity.a = currentOpacity;
            spriteRenderer.color = barOpacity;

        }
    }

    public void fadeInObject()
    {
        if (currentOpacity != 100f)
        {
            float step = Time.deltaTime * 2;
            currentOpacity = Mathf.MoveTowards(currentOpacity, 1f, step);

            Color barOpacity = spriteRenderer.color;
            barOpacity.a = currentOpacity;
            spriteRenderer.color = barOpacity;

        }

    }


}