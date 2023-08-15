using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityBar : MonoBehaviour
{
    public GameObject firstObject;
    private float barLength, barPos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerController playerControllerReference = firstObject.GetComponent<playerController>();
        float sanity = playerControllerReference.sanity;
        barLength = sanity / 20 - 1;
        Vector2 newLength = transform.localScale;
        newLength.x = barLength;
        transform.localScale = newLength;

        barPos = barLength / 2 + 8;
        Vector3 newPos = transform.localPosition;
        newPos.x = barPos;
        transform.localPosition = newPos;

    }
}