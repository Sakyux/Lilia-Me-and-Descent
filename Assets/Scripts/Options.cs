using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    // buttons
    public Button fullScreen, back, newGame;
    public Slider volume;
    public TMP_Dropdown screenResolution;
    public GameObject optionsPanel;
    private bool isFullscreen = true;
    public static float volumeLevel = 1;
    public static int resolutionIndex = 1;
    public Toggle toggleFullscreen;
    public TMP_Text volumeText;

    //public GameObject SliderTest;


    void Start()
    {
        //SliderTest = GameObject.Find("Slider");
        volume = GameObject.Find("Slider").GetComponent<Slider>();
        fullScreen = GameObject.Find("FullScreenButton").GetComponent<Button>();
        back = GameObject.Find("BackButton").GetComponent<Button>();
        newGame = GameObject.Find("NewGameButton").GetComponent<Button>();
       
        
        optionsPanel = GameObject.Find("Options");
        
        volumeText = GameObject.Find("VolumeText").GetComponent<TMP_Text>();///
        screenResolution = GameObject.Find("ResolutionDropDown").GetComponent<TMP_Dropdown>();//
        toggleFullscreen = GameObject.Find("FullScreenToggle").GetComponent<Toggle>();//

        //WIP
        ChangeResolution(resolutionIndex);
        AudioListener.volume = volumeLevel;
        volume.value = volumeLevel;

        if (volume != null && volume.IsActive())
        {
            if (Input.GetKey(KeyCode.LeftArrow)) volume.value -= 0.5f;
            if (Input.GetKey(KeyCode.RightArrow)) volume.value += 0.5f;
        }

        fullScreen.onClick.AddListener(FullScreen);
        volume.onValueChanged.AddListener(ChangeVolume);
        screenResolution.onValueChanged.AddListener(ChangeResolution);
        back.onClick.AddListener(Back);

        Invoke("DisableOptions", 0.01f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) Back();
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
        newGame.Select();
    }

    void DisableOptions()
    {
        optionsPanel.SetActive(false);
    }
}
