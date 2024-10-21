using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class AudioData : ScriptableObject
{

    [Tooltip("ミニベタ移動音")] public AudioClip miniMove;
    [Tooltip("中ベタ移動音")] public AudioClip tyuuMove;
    [Tooltip("第ベタ移動音")] public AudioClip bigMove;
    [Tooltip("打撃音")] public AudioClip attack;
    [Tooltip("スタン音")] public AudioClip sutun;
    [Tooltip("爆発音")] public AudioClip bom;
    [Tooltip("吸う音")] public AudioClip inhale;
    [Tooltip("吸い込んだ音")] public AudioClip Inhaled;

}
