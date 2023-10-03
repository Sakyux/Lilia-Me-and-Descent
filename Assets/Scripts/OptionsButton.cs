using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour
{
    public Button Options;
    public GameObject OptionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Disable", 0.01f);
        Options.onClick.AddListener(OptionsMenu);
    }

    // Update is called once per frame
    void OptionsMenu()
    {
        OptionsPanel.SetActive(true);
    }
    void Disable()
    {
        OptionsPanel.SetActive(false);
    }
}
