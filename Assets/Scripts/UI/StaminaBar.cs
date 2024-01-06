using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    public Image StaminaBarLeft, StaminaBarRight;
    public float currentBarOpacity;
    public float targetOpacity = 0f;
    public PlayerController playerController;
    public float stamina;
    private float currentValue = 0;
    private bool canSprint;

    private void Start()
    {
        StaminaBarLeft = GameObject.Find("StaminaBarLeft").GetComponent<Image>();
        StaminaBarRight = GameObject.Find("StaminaBarRight").GetComponent<Image>();
        playerController = GameObject.Find("Lilia").GetComponent<PlayerController>();
        StaminaBarLeft.color = new Color(1, 1, 1, 0);
        StaminaBarRight.color = new Color(1, 1, 1, 0);

    }
    // Update is called once per frame
    void Update()
    {
        stamina = playerController.stamina;

        StaminaBarLeft.fillAmount = (stamina / 100 - 0.01f);
        StaminaBarRight.fillAmount = (stamina / 100 - 0.01f);

        // turning red
        if (stamina >= 50) canSprint = true;
        if (stamina <= 1) canSprint = false;

        if (stamina < 99)
        {
            if (canSprint) currentValue = 1 - stamina / 50;
            else if (canSprint) currentValue = 1;
            currentValue = Mathf.Clamp01(currentValue);
            Color lerpedColour = Color.Lerp(Color.white, Color.red, currentValue);
            StaminaBarLeft.color = lerpedColour;
            StaminaBarRight.color = lerpedColour;
        }
        // turning transparent

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
