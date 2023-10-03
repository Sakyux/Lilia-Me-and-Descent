using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //Panel must be created on the canvas and then dragged into this section in the inspector
    public GameObject panel;

    void Start()
    {
        Invoke("Disable", 0.01f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            panel.SetActive(true);
            Debug.Log("trigger was triggered");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
            panel.SetActive(false);
            Debug.Log("trigger was trigger'nted");
       
    }

    /*Alternative
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            panel.SetActive(true);
            Debug.Log("trigger was triggered");
        }
    }
    */

    void Disable()
    {
        panel.SetActive(false);
    }
}

