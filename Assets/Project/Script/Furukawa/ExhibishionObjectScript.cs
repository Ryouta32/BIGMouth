using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhibishionObjectScript:MonoBehaviour
{
    public void PlayAudio()
    {
        AudioManager.manager.Play(AudioManager.manager.data.emergency);
    }
}
