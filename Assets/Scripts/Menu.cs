using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu, options;
    private bool toggle;
    public Button Inventory, OptionsButton, MainMenuButton, QuitButton, OptionsStartButton;
    public PlayerController playerController;
    private void Start()
    {
        menu.SetActive(false);
        OptionsButton.onClick.AddListener(OptionsMenu);
        MainMenuButton.onClick.AddListener(MainMenu);
        QuitButton.onClick.AddListener(Exit);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            toggle = !toggle;
            menu.SetActive(toggle);
            Inventory.Select();
        }
        if (toggle) playerController.canMove = false;
        else playerController.canMove = true;

        if (Input.GetKeyDown(KeyCode.X)) options.SetActive(false);
    }

    public void OptionsMenu()
    {
        options.SetActive(true);
        OptionsStartButton.Select();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
