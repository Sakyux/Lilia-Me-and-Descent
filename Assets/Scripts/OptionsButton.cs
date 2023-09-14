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
        OptionsPanel.SetActive(false);
        Options.onClick.AddListener(OptionsMenu);
    }

    // Update is called once per frame
    void OptionsMenu()
    {
        OptionsPanel.SetActive(true);
    }
}
