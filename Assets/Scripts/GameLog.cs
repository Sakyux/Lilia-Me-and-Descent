using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLog : MonoBehaviour
{
    // Private VARS
    private List<string> Eventlog = new List<string>();
    private string guiText = "";
    private Rect LogBox = new Rect(0, 0, Screen.width/2, Screen.height);

    // Public VARS
    public int maxLines = 5;

    void OnGUI()
    {
        GUI.Label(LogBox, guiText, GUI.skin.label);
    }

    public void AddEvent(string eventString)
    {
        Eventlog.Add(eventString + "\n");

        if (Eventlog.Count >= maxLines)
            Eventlog.RemoveAt(0);

        guiText = "";

        foreach (string logEvent in Eventlog)
        {
            guiText += logEvent;
            guiText += "";
        }
    }
}
