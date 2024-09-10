using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugText : MonoBehaviour
{
    public static DebugText LogText=new DebugText();
    private TextMeshProUGUI text;
    private List<string> logs = new List<string>();
    private int count=20;
    private string logtext;
    // Start is called before the first frame update
    void Start()
    {
        LogText.text = GetComponent<TextMeshProUGUI>();
    }

    public void Log2<T>(T a)
    {
        string b;
        logtext = "";
        for (int i = 0; i < logs.Count; i++)
            logtext += logs[i] + "\n";

        text.text = logtext;
        if (logtext.Contains(a.ToString()))
        {
            return;
        }
        else
        {
            logs.Add(a.ToString());

            for (int i = 0; i < logs.Count; i++)
                logtext += logs[i] + "\n";

            LogText.text.text = logtext;

            Debug.Log(logs.Count);

        }

        if (count <= logs.Count) {
            logs.RemoveAt(0);
        }
    }
}
