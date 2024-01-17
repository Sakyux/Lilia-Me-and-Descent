using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
    public Button menuStartButton;
    public GameObject menuPanel;
    void Start()
    {
        menuStartButton = GameObject.Find("KeyItemsButton").GetComponent<Button>();
        menuPanel = GameObject.Find("MenuPanel");

        Invoke("DisableJournal", 0.01f);
    }

    private void Update()
    {
        if (Input.GetButtonDown("menu" + Options.controlOpt)) Back();
    }
    void Back()
    {
        menuPanel.SetActive(true);
        menuStartButton.Select();
        gameObject.SetActive(false);
        
    }
    private void DisableJournal()
    {
        gameObject.SetActive(false);
    }
}
