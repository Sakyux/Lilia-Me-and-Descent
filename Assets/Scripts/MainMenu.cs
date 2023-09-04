using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    
    // buttons
    public Button newGameButton, optionsButton, exitButton, fullScreenButton;
    
    // menus
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public string mainScene;
    void Start()
    {
        optionsMenu.SetActive(false);

        newGameButton.Select();

        // button interactions
        newGameButton.onClick.AddListener(NewGame);
        optionsButton.onClick.AddListener(Options);
        exitButton.onClick.AddListener(Exit);
    }

    void NewGame()
    {
        SceneManager.LoadScene(mainScene);
        
    }
    void Options()
    {
        optionsMenu.SetActive(true);
        fullScreenButton.Select();
    }
    void Exit()
    {
        Application.Quit();
    }
}
