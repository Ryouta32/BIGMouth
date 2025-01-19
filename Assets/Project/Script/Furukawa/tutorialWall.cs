using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialWall : MonoBehaviour
{
    tutorialScript tutorialSC;
    [SerializeField] GameObject wall;
    void Start()
    {
        tutorialSC = GameObject.Find("tutorial").GetComponent<tutorialScript>();
        wall.SetActive(true);
        tutorialSC.SetWall(this);
    }
    public void Play()
    {
        wall.SetActive(true);
    }
    public void holeHit()
    {
        tutorialSC.CLEAR();
    }
}
