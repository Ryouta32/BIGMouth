using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LogSC : MonoBehaviour
{
    public static string log;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = log;
    }
}
