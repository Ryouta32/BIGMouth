using UnityEngine;
using TMPro;
public class LogSC : MonoBehaviour
{
    public static string log;
    [SerializeField] TextMeshProUGUI text;
    void Update()
    {
        text.text = log;
    }
}
