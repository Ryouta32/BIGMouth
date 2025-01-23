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
            if(clip != null)
            {
                audio.clip = clip;
                BIGBallSC.BIGFlag = false;
                audio.volume = 0.8f;
                audio.Play();
            }
        }
    }
}
