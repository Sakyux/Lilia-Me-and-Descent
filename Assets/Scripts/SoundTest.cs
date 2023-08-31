using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTest : MonoBehaviour
{
    public Button soundTest;
    public AudioClip test;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        soundTest.onClick.AddListener(TestSound);
        audioSource = GetComponent < AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void TestSound()
    {
        if (test != null) audioSource.PlayOneShot(test);
    }
}
