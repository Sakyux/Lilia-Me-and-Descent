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
    public SaveData saveData;
    private void Start()
    {
        menu = GameObject.Find("MenuPanel");
        options = GameObject.Find("GameOptions");
        inventory = GameObject.Find("KeyItems");
        saveData = GameObject.Find("SaveGame").GetComponent<SaveData>();

        death = GameObject.Find("DeathScreenManager").GetComponent<Death>();
        playerController = GameObject.Find("Lilia").GetComponent<PlayerController>();
        keyItems = GameObject.Find("KeyItems").GetComponent<KeyItems>();
        KeyItemsButton = GameObject.Find("KeyItemsButton").GetComponent<Button>();
        RespawnButton = GameObject.Find("RespawnButton").GetComponent<Button>();
        OptionsButton = GameObject.Find("GameOptionsButton").GetComponent<Button>();
        MainMenuButton = GameObject.Find("MainMenuButton").GetComponent<Button>();
        QuitButton = GameObject.Find("QuitGameButton").GetComponent<Button>();
        OptionsStartButton = GameObject.Find("FullScreenButton").GetComponent<Button>();
        InventoryStartButton = GameObject.Find("Slot1").GetComponent<Button>();

        KeyItemsButton.onClick.AddListener(KeyItems);
        RespawnButton.onClick.AddListener(death.respawn);
        OptionsButton.onClick.AddListener(OptionsMenu);
        MainMenuButton.onClick.AddListener(MainMenu);
        QuitButton.onClick.AddListener(Exit);
        Invoke("DisableMenu", 0.01f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }

        CheckForMenus();

        if (Input.GetKeyDown(KeyCode.Tab)) options.SetActive(false);
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
        saveData.SaveGameData();
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        saveData.SaveGameData();
        Application.Quit();
    }

    private void CheckForMenus()
    {
        if (menu.activeSelf || inventory.activeSelf || options.activeSelf) playerController.canMove = false;
        else playerController.canMove = true;
    }

    void DisableMenu()
    {
        menu.SetActive(false);
        inventory.SetActive(false);
        playerController.canMove = true;
    }
}
