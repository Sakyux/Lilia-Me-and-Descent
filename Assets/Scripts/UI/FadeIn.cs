using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.Find("FadeIn");
        Invoke("Disable", 0.01f);
    }

    // Update is called once per frame
    void Disable()
    {
        image.SetActive(false);
    }
}
