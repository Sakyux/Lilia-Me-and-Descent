using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    // buttons
    public Button fullScreen, volume, screenResolution, back;
    public GameObject optionsPanel;
    private bool isFullscreen = true;
   
    void Start()
    {
        fullScreen.onClick.AddListener(FullScreen);
        //back.onClick.AddListener(Back);
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
    void Back()
    {
        optionsPanel.SetActive(false);
    }
}
