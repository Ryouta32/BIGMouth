using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetaText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textText;
    public static int betacount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textText.text = betacount.ToString();
    }
}
