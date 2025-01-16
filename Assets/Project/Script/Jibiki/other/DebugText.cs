using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Text_Debug : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textText;
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        obj = GameObject.Find("yukaCollider");

        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.Floor))
            {
                textText.text = obj.transform.localScale.ToString();
            }
        }
    }
}
