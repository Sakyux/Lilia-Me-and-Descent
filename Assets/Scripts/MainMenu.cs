using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // buttons
    public Button newGameButton;
    public Button optionsButton;

    // menus
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public PlayerController playerController;
    void Start()
    {
        

        optionsMenu.SetActive(false);

        // button interactions
        optionsButton.onClick.AddListener(Options);
        newGameButton.onClick.AddListener(NewGame);
    }

    public void NewGame()
    {
        mainMenu.SetActive(false);
        playerController.isDead = false;
    }
    void Options()
    {
        optionsMenu.SetActive(true);
    }
}
