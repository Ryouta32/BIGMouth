using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialWall : MonoBehaviour
{
    tutorialScript tutorialSC;
    void Start()
    {
        tutorialSC = GameObject.Find("tutorial").GetComponent<tutorialScript>();
        tutorialSC.SetWall(this);
    }
    public void holeHit()
    {
        tutorialSC.CLEAR();
    }
}
