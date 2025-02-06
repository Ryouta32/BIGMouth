using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum tutorialUIState
{
    start, stun, kill, wall
}
public class TutorialUIScript : MonoBehaviour
{
    [SerializeField] Animator anima;
    [SerializeField] tutorialScript tutorialScript;
    [SerializeField] GameObject batten;
    [SerializeField] TutorialUIChaild[] UIs;
    [SerializeField] bool[] states;
    private void Start()
    {
        batten.SetActive(false);
        //anima = GetComponent<Animator>();
        SetState(tutorialUIState.start);
    }
    public void SetState(tutorialUIState state)
    {
        for (int i = 0; i < UIs.Length; i++)
            UIs[i].SetState(state);

        switch (state)
        {
            case tutorialUIState.start:
                if (states[(int)tutorialUIState.start])
                {
                    states[(int)tutorialUIState.start] = false;
                    AudioManager.manager.Stop();
                    AudioManager.manager.Play(AudioManager.manager.data.tutorial1);
                }
                break;

            case tutorialUIState.stun:
                if (states[(int)tutorialUIState.stun])
                {
                    states[(int)tutorialUIState.stun] = false;
                    AudioManager.manager.Stop();
                    AudioManager.manager.Play(AudioManager.manager.data.tutorial2);
                }
                break;

            case tutorialUIState.kill:
                if (states[(int)tutorialUIState.kill])
                {
                    states[(int)tutorialUIState.kill] = false;
                    AudioManager.manager.Stop();
                    AudioManager.manager.Play(AudioManager.manager.data.tutorial3);
                }
                break;
            case tutorialUIState.wall:
                if (states[(int)tutorialUIState.wall])
                {
                    states[(int)tutorialUIState.wall] = false;
                    AudioManager.manager.Stop();
                    AudioManager.manager.Play(AudioManager.manager.data.tutorial4);
                }
                break;
        }
    }
    public void Retry()
    {
        batten.SetActive(true);
        //anima.SetTrigger("Sippai");
    }
    public void animaEnd()
    {
        tutorialScript.Play();
        batten.SetActive(false);
    }

}
