using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // buttons
    public Button newGameButton;
    public Button optionsButton;

    // menus
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public string mainScene;
    void Start()
    {
        optionsMenu.SetActive(false);

        // button interactions
        optionsButton.onClick.AddListener(Options);
        newGameButton.onClick.AddListener(NewGame);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(mainScene);
        
    }
    void Options()
    {
        optionsMenu.SetActive(true);
    }
}
