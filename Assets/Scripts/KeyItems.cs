using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyItems : MonoBehaviour
    {
        public Button Slots;
        public string item;
    public List<KeyItems> slotsList = new List<KeyItems>();
        void Start()
        {
            //Slot1.Select();
           // Slot1.onClick.AddListener(PickItem);
        }
        void Update()
        {
            
        }

        void PickItem()
        {
            ChangeSelected(1);
        }

        void ChangeSelected(int slotNum)
        {
        //selected = itemTest;
        }
    }
