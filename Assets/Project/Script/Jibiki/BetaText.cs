using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetaText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textText;
    public static int betacount;

    // Update is called once per frame
    void Update()
    {
        textText.text = betacount.ToString();
    }
}
