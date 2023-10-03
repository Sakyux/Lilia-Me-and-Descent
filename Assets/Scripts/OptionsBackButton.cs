using UnityEngine;
using UnityEngine.UI;

public class OptionsBackButton : MonoBehaviour
{
    public Button Back;
    public GameObject OptionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        Back.onClick.AddListener(GoBack);
    }

    // Update is called once per frame
    void GoBack()
    {
        OptionsPanel.SetActive(false);
    }
}
