using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    
    // buttons
    public Button continueButton, newGameButton, optionsButton, exitButton, fullScreenButton;
    
    // menus
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public string mainScene;
    void Start()
    {
        SaveData.LoadOptionsData();

        newGameButton.Select();

        // button interactions
        continueButton.onClick.AddListener(Continue);
        newGameButton.onClick.AddListener(NewGame);
        optionsButton.onClick.AddListener(Options);
        exitButton.onClick.AddListener(Exit);
    }
    void Continue()
    {
        SaveData.load = true;
        SceneManager.LoadScene(mainScene);
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
