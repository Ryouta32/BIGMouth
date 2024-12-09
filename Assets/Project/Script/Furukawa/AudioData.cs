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
    [Tooltip("噴射")] public AudioClip　injection;

    [Header("中ベタ")]
    [Tooltip("触手が穴から出るとき")] public AudioClip tyuuout;
    [Tooltip("触手が穴に入る時")] public AudioClip tyuuin;
    [Tooltip("触手が倒れた時")] public AudioClip falldown;
    [Tooltip("中ベタの穴が消える")] public AudioClip hole;

    [Header("ステージ")]
    [Tooltip("よごれが飛び散る")] public AudioClip scatter;
    [Tooltip("現実が割れ始める")] public AudioClip crack;
    [Tooltip("よごれで現実が割れる")] public AudioClip sbreak;

}
