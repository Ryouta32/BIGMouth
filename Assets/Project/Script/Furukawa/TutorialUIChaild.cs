using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUIChaild : MonoBehaviour
{
    [SerializeField] GameObject back;
    [SerializeField] GameObject main;
    [SerializeField] Vector3 mainPos;
    [SerializeField] Vector3 backPos;
    [SerializeField]tutorialUIState mystate;
    private Vector3 startPos;
    private void Awake()
    {
        startPos = transform.position;
        mainPos += startPos;
        backPos += startPos;
    }
    public void SetState(tutorialUIState state)
    {
        if(state ==mystate)
        {
            back.transform.position = backPos;
            main.transform.position = mainPos;
        }
        else
        {
            back.transform.position = startPos;
            main.transform.position = startPos;
        }

    }
}
