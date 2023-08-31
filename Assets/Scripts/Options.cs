using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    // buttons
    public Button fullScreen, screenResolution, back;
    public Slider volume;
    public GameObject optionsPanel;
    private bool isFullscreen = true;
   
    void Start()
    {
        fullScreen.onClick.AddListener(FullScreen);
        volume.onValueChanged.AddListener(ChangeVolume);
        //back.onClick.AddListener(Back); 
        back.onClick.AddListener(Back);
        
    }

    private void FullScreen()
    {
        isFullscreen = !isFullscreen;
        Screen.fullScreen = isFullscreen;
        if (Screen.fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            Debug.Log("true");
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("false");
        }
        if (Screen.fullScreen) Debug.Log("fullscreen");
        else Debug.Log("not fullscreen");
    }

    private void ChangeVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
        Debug.Log(AudioListener.volume);
    }
    void Back()
    {
        optionsPanel.SetActive(false);
    }
}
