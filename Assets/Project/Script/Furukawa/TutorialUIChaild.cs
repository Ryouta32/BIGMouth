using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUIChaild : MonoBehaviour
{
    //[SerializeField] GameObject back;
    [SerializeField] GameObject waku;
    [SerializeField] Vector3 mainPos;
    //[SerializeField] Vector3 backPos;
    [SerializeField]tutorialUIState mystate;
    [SerializeField] MeshRenderer image;
    private Vector3 startPos;
    private void Awake()
    {
        startPos = transform.position;
        mainPos += startPos;
        //backPos += startPos;
    }
    public void SetState(tutorialUIState state)
    {
        if(state ==mystate)
        {
            transform.position = mainPos;
            image.material.color = Color.white;
            waku.SetActive(true);
            //back.transform.position = backPos;
            //main.transform.position = mainPos;
        }
        else
        {
            waku.SetActive(false);
            transform.position = startPos;
            image.material.color = Color.gray;
            //back.transform.position = startPos;
            //main.transform.position = startPos;
        }

    }
}
