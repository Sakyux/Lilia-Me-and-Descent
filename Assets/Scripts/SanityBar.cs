using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    public Image sanityBarBackGround;
    public Image sanityBar;
    public PlayerController playerController;
    public float sanity;
    // Update is called once per frame

    private void Start()
    {
        sanityBar = GameObject.Find("SanityBarInner").GetComponent<Image>();
        sanityBarBackGround = GameObject.Find("SanityBarBackground").GetComponent<Image>();
        playerController = GameObject.Find("Lilia").GetComponent<PlayerController>();
    }
    void Update()
    {

        sanity = PlayerController.sanity;
        sanityBar.fillAmount = (1 - sanity / 100);

        if (playerController.isDead == true)
        {
            sanityBar.enabled = false;
            sanityBarBackGround.enabled = false;
        }
        else
        {
            sanityBar.enabled = true;
            sanityBarBackGround.enabled = true;
        }
    }
}
