using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    // buttons
    public Button fullScreen, controls, back, menuStartButton;
    public Slider volume;
    public TMP_Dropdown screenResolution;
    public GameObject optionsPanel;
    private bool isFullscreen = true;
    public static float volumeLevel = 1;
    public static int resolutionIndex = 1;
    public static string controlOpt = "_old";
    public Toggle toggleFullscreen;
    public TMP_Text volumeText, controlsText;
    void Start()
    {
        if(GameObject.Find("GameOptions") == null) optionsPanel = GameObject.Find("Options");
        else optionsPanel = GameObject.Find("GameOptions");

        if (GameObject.Find("NewGameButton") == null) menuStartButton = GameObject.Find("KeyItemsButton").GetComponent<Button>();
        else menuStartButton = GameObject.Find("NewGameButton").GetComponent<Button>();

        volumeText = GameObject.Find("VolumeText").GetComponent<TMP_Text>();
        controlsText = GameObject.Find("ControlsButton").GetComponent<TMP_Text>();
        toggleFullscreen = GameObject.Find("FullScreenToggle").GetComponent<Toggle>();
        screenResolution = GameObject.Find("ResolutionDropDown").GetComponent<TMP_Dropdown>();
        volume = GameObject.Find("Slider").GetComponent<Slider>();
        fullScreen = GameObject.Find("FullScreenButton").GetComponent<Button>();
        controls = GameObject.Find("ControlsButton").GetComponent<Button>();
        back = GameObject.Find("BackButton").GetComponent<Button>();
        
        
        ChangeResolution(resolutionIndex);
        UpdateControlsButton();
        AudioListener.volume = volumeLevel;
        volume.value = volumeLevel;

        if (volume != null && volume.IsActive())
        {
            if (Input.GetKey(KeyCode.A)) volume.value -= 0.5f;
            if (Input.GetKey(KeyCode.D)) volume.value += 0.5f;
        }

        fullScreen.onClick.AddListener(FullScreen);
        volume.onValueChanged.AddListener(ChangeVolume);
        screenResolution.onValueChanged.AddListener(ChangeResolution);
        controls.onClick.AddListener(ChangeControls);
        back.onClick.AddListener(Back);

        Invoke("DisableOptions", 0.01f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Back();
    }

    private void FullScreen()
    {
        isFullscreen = !isFullscreen;
        Screen.fullScreen = isFullscreen;
        toggleFullscreen.isOn = !toggleFullscreen.isOn;
    }

    private void ChangeVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
        Debug.Log(AudioListener.volume);
        volumeLevel = AudioListener.volume;

        if (EventSystem.current.currentSelectedGameObject == volume.gameObject)
        {
            volumeText.color = new Color32(157, 154, 195, 255);
        }
    }

    private void ChangeControls()
    {
        if (controlOpt == "_old") controlOpt = "_new";
        else controlOpt = "_old";
        UpdateControlsButton();
    }
    private void UpdateControlsButton()
    {
        if (controlOpt == "_old") controlsText.text = "Controls: Old-School";
        else controlsText.text = "Controls: Modern";
    }

    private void ChangeResolution(int optionIndex)
    {
        switch (optionIndex)
        {
            case 0: // 1920 x 1080
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1: // 1440 x 900
                Screen.SetResolution(1440, 900, Screen.fullScreen);
                break;
            case 2: // 1366 x 768
                Screen.SetResolution(1366, 768, Screen.fullScreen);
                break;
        }
        resolutionIndex = optionIndex;
    }

    void Back()
    {
        optionsPanel.SetActive(false);
        menuStartButton.Select();
    }

    void DisableOptions()
    {
        optionsPanel.SetActive(false);
    }
}
