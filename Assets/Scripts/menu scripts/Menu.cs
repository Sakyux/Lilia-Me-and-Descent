using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu, options, inventory, journal;
    public Death death;
    private bool toggle;
    public Button KeyItemsButton, JournalButton, RespawnButton, OptionsButton, MainMenuButton, QuitButton, OptionsStartButton, InventoryStartButton;
    public KeyItems keyItems;
    public SaveData saveData;
    private void Start()
    {
        menu = GameObject.Find("MenuPanel");
        options = GameObject.Find("GameOptions");
        inventory = GameObject.Find("KeyItems");
        journal = GameObject.Find("Journal");
        saveData = GameObject.Find("SaveGame").GetComponent<SaveData>();

        death = GameObject.Find("DeathScreenManager").GetComponent<Death>();
        keyItems = GameObject.Find("KeyItems").GetComponent<KeyItems>();
        KeyItemsButton = GameObject.Find("KeyItemsButton").GetComponent<Button>();
        JournalButton = GameObject.Find("JournalButton").GetComponent<Button>();
        RespawnButton = GameObject.Find("RespawnButton").GetComponent<Button>();
        OptionsButton = GameObject.Find("GameOptionsButton").GetComponent<Button>();
        MainMenuButton = GameObject.Find("MainMenuButton").GetComponent<Button>();
        QuitButton = GameObject.Find("QuitGameButton").GetComponent<Button>();
        OptionsStartButton = GameObject.Find("FullScreenButton").GetComponent<Button>();
        InventoryStartButton = GameObject.Find("Slot1").GetComponent<Button>();

        KeyItemsButton.onClick.AddListener(KeyItems);
        JournalButton.onClick.AddListener(Journal);
        RespawnButton.onClick.AddListener(death.respawn);
        OptionsButton.onClick.AddListener(OptionsMenu);
        MainMenuButton.onClick.AddListener(MainMenu);
        QuitButton.onClick.AddListener(Exit);
        Invoke("DisableMenu", 0.01f);
    }
    void Update()
    {
        if (Input.GetButtonDown("menu" + Options.controlOpt))
        {
            ToggleMenu();
        }

        CheckForMenus();
    }
    public void ToggleMenu()
    {
        if(menu.activeSelf) toggle = false; 
        else toggle = true;
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
    public void Journal()
    {
        journal.SetActive(true);
        menu.SetActive(false);
    }
    public void OptionsMenu()
    {
        options.SetActive(true);
        OptionsStartButton.Select();
        menu.SetActive(false);
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
        if (menu.activeSelf || inventory.activeSelf || options.activeSelf || journal.activeSelf) PlayerController.canMove = false;
        else PlayerController.canMove = true;
    }

    void DisableMenu()
    {
        menu.SetActive(false);
        //inventory.SetActive(false);
        PlayerController.canMove = true;
    }
}
