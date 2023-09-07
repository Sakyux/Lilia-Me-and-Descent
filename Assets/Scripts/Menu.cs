using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public bool toggle;
    public Button Inventory;
    public PlayerController playerController;
    private void Start()
    {
        menu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            toggle = !toggle;
            menu.SetActive(toggle);
            Inventory.Select();
        }
        if (toggle) playerController.canMove = false;
        else playerController.canMove = true;
    }
}
