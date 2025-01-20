using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMAudio : MonoBehaviour
{
    AudioSource audio;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BIGBallSC.BIGFlag)
        {
            audio.clip = clip;
            BIGBallSC.BIGFlag = false;
        }
    }
}
