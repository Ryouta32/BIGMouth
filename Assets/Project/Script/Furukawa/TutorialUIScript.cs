using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum tutorialUIState
{
    start,stun,kill
}
public class TutorialUIScript : MonoBehaviour
{
    Animator anima;
    [SerializeField]tutorialScript tutorialScript;
    [SerializeField] GameObject batten;
    [SerializeField] TutorialUIChaild[] UIs;
    private void Start()
    {
        batten.SetActive(false);
        anima = GetComponent<Animator>();
        SetState(tutorialUIState.start);
    }
    public void SetState(tutorialUIState state)
    {
        for(int i=0;i<UIs.Length;i++)
        UIs[i].SetState(state);
    }
    public void Retry()
    {
        batten.SetActive(true);
        anima.SetTrigger("Sippai");
    }
    public void animaEnd()
    {
        tutorialScript.setanima(true);
        batten.SetActive(false);
    }

}
