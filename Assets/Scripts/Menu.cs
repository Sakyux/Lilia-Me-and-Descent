using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu, options, inventory;
    public Death death;
    private bool toggle;
    public Button KeyItemsButton, RespawnButton, OptionsButton, MainMenuButton, QuitButton, OptionsStartButton, InventoryStartButton;
    public PlayerController playerController;
    public KeyItems keyItems;
    private void Start()
    {
        inventory.SetActive(false);
        menu.SetActive(false);
        KeyItemsButton.onClick.AddListener(KeyItems);
        RespawnButton.onClick.AddListener(death.respawn);
        OptionsButton.onClick.AddListener(OptionsMenu);
        MainMenuButton.onClick.AddListener(MainMenu);
        QuitButton.onClick.AddListener(Exit);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ToggleMenu();
        }
        if (toggle) playerController.canMove = false;
        else playerController.canMove = true;

        if (Input.GetKeyDown(KeyCode.X)) options.SetActive(false);
    }
    public void ToggleMenu()
    {
            toggle = !toggle;
            menu.SetActive(toggle);
            KeyItemsButton.Select();
    }
    public void KeyItems()
    {
        keyItems.ReloadKeyItems();
        inventory.SetActive(true);
        InventoryStartButton.Select();
        menu.SetActive(false);
    }
    public void OptionsMenu()
    {
        options.SetActive(true);
        OptionsStartButton.Select();
    }
    public void MainMenu()
    {
        SaveData.Instance.SaveGameData();
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        SaveData.Instance.SaveGameData();
        Application.Quit();
    }
}
