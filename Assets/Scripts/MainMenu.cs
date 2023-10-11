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
        continueButton = GameObject.Find("ContinueButton").GetComponent<Button>();
        newGameButton = GameObject.Find("NewGameButton").GetComponent<Button>();
        optionsButton = GameObject.Find("OptionsButton").GetComponent<Button>();
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        fullScreenButton = GameObject.Find("FullScreenButton").GetComponent<Button>();
        optionsMenu = GameObject.Find("Options");
        mainMenu = GameObject.Find("MainMenu");

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
