using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Text_Debug : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textText;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.WallFace))
            {
                textText.text = classification.transform.localScale.ToString();
            }
        }
    }
}
