using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    // buttons
    public Button fullScreen, back, newGame;
    public Slider volume;
    public TMP_Dropdown screenResolution;
    public GameObject optionsPanel;
    private bool isFullscreen = true;
   
    void Start()
    {
        
        if(volume != null && volume.IsActive())
        {
            if (Input.GetKey(KeyCode.LeftArrow)) volume.value -= 0.5f;
            if (Input.GetKey(KeyCode.RightArrow)) volume.value += 0.5f;
        }

        fullScreen.onClick.AddListener(FullScreen);
        volume.onValueChanged.AddListener(ChangeVolume);
        screenResolution.onValueChanged.AddListener(ChangeResolution); 
        back.onClick.AddListener(Back);
    }

    private void FullScreen()
    {
            isFullscreen = !isFullscreen;
            Screen.fullScreen = isFullscreen;
    }

    private void ChangeVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
        Debug.Log(AudioListener.volume);
    }

    private void ChangeResolution(int optionIndex)
    {
        switch (optionIndex)
        {
            case 0: // 1920 x 1080
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1: // 1366 x 768
                Screen.SetResolution(1366, 768, Screen.fullScreen);
                break;
            case 2: // 1440 x 900
                Screen.SetResolution(1440, 900, Screen.fullScreen);
                break;
        }
    }

    void Back()
    {
        optionsPanel.SetActive(false);
        newGame.Select();
    }
}
