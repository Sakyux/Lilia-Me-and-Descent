using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnButton : MonoBehaviour
{

    public Death Death;
    public Button respawnButton;

    // Start is called before the first frame update.
    void Start()
    {
        respawnButton.onClick.AddListener(RespawnPlayer);
    }

    private void RespawnPlayer()
    {
        Death.respawn();
    }

}
