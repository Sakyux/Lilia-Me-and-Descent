using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    public Image StaminaBarLeft, StaminaBarRight;
    public float currentBarOpacity;
    public float targetOpacity = 0f;
    public PlayerController playerController;
    public float stamina;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stamina = playerController.stamina;

        StaminaBarLeft.fillAmount = (stamina / 100 - 0.01f);
        StaminaBarRight.fillAmount = (stamina / 100 - 0.01f);

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

        if (playerController.isDead == true)
        {
            StaminaBarLeft.enabled = false;
            StaminaBarRight.enabled = false;
        }
        else
        {
            StaminaBarLeft.enabled = true;
            StaminaBarRight.enabled = true;
        }
    }
}
