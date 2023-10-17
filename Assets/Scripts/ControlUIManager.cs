using UnityEngine;

public class ControlUIManager : MonoBehaviour
{
    public GameObject ControlUI;
    // Start is called before the first frame update
    void Start()
    {
        ControlUI = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
