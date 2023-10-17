using UnityEngine;
using UnityEngine.UI;

public class ControlUIManager : MonoBehaviour
{
    public Image ControlUI;
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        ControlUI = transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>();
    }

    private void Update()
    {
        if (active)
        {
            ControlUI.color = new Color(ControlUI.color.r, ControlUI.color.g, ControlUI.color.b, Mathf.Clamp(ControlUI.color.a + 0.005f, 0, 1));
        }
        else ControlUI.color = new Color(ControlUI.color.r, ControlUI.color.g, ControlUI.color.b, Mathf.Clamp(ControlUI.color.a - 0.005f, 0, 1));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Lilia"))
        {
            active = true;
            Debug.Log(active);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Lilia"))
        {
            active = false;
        }
    }
}
