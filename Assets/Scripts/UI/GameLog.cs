using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLog : MonoBehaviour
{
    // Private VARS
    private List<string> Eventlog = new List<string>();
    private string guiText = "";
    private Rect LogBox = new Rect(0, 0, Screen.width/2, Screen.height);
    private float time = 0;

    // Public VARS
    public int maxLines = 5;
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            time = 0;
            if (Eventlog.Count != 0)
            {
                Eventlog.RemoveAt(0);
                AddEvent(null);
            }
        }
    }
    void OnGUI()
    {
        GUI.Label(LogBox, guiText, GUI.skin.label);
    }

    public void AddEvent(string eventString)
    {
        if (eventString != null) Eventlog.Add(eventString + "\n");

        if (Eventlog.Count >= maxLines)
            Eventlog.RemoveAt(0);

        guiText = "";

        foreach (string logEvent in Eventlog)
        {
            guiText += logEvent;
            guiText += "";
        }
        time = 0;
    }
}
