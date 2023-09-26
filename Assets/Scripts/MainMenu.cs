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
        newGameButton.Select();

        // button interactions
        continueButton.onClick.AddListener(Continue);
        newGameButton.onClick.AddListener(NewGame);
        optionsButton.onClick.AddListener(Options);
        exitButton.onClick.AddListener(Exit);
    }
    void Continue()
    {
        SceneManager.LoadScene(mainScene);
        SaveData.Instance = null;
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
