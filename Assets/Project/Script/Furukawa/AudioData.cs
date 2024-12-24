using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class AudioData : ScriptableObject
{
    [Header("ミニベタ関係")]
    [Tooltip("T-1 walk")] public AudioClip miniMove;
    [Tooltip("T-1 Bom")] public AudioClip miniBom;
    [Tooltip("T-3 foll down")] public AudioClip miniFollDown;
    [Tooltip("T-4 out")] public AudioClip miniOut;
    [Tooltip("T-5 in")] public AudioClip miniIn;
    [Tooltip("T-6 hole")] public AudioClip miniHole;
    [Tooltip("T-7 boss")] public AudioClip miniBoss;
    [Tooltip("T-8 fountain")] public AudioClip miniFoimtain;
    [Tooltip("T-9 stun")] public AudioClip ministun;
    [Tooltip("T-10 mush")] public AudioClip mush;

    [Header("掃除機")]
    [Tooltip("C-1clean")] public AudioClip cleanerClean;
    [Tooltip("C-2 charge")] public AudioClip cleanerCharge;
    [Tooltip("C-3 suction")] public AudioClip cleanerSuction;
    [Tooltip("C-4 pon")] public AudioClip cleanerPon;
    [Tooltip("C-5")] public AudioClip cleaner5;
    [Tooltip("C-6 splash")] public AudioClip cleanerSplash;
    [Tooltip("C-7 fix")] public AudioClip cleanerFix;

    [Header("ステージ")]
    [Tooltip("S-2 scatter")] public AudioClip stageScatetr;
    [Tooltip("S-3 crack")] public AudioClip stageCrack;
    [Tooltip("S-4 break")] public AudioClip stageBreak;
    [Tooltip("S-5 emergency")] public AudioClip stageEnergency;
    [Tooltip("S-6 emergency2")] public AudioClip stageEnergency2;

    [Header("システム")]
    [Tooltip("0-4 Abutton")] public AudioClip systemAbutton;
    [Tooltip("0-5 Bbutton")] public AudioClip systemBbutton;
    [Tooltip("0-6 stage")] public AudioClip systemStage;
    [Tooltip("0-7 pointer")] public AudioClip systemPointer;

    //[Tooltip("中ベタ移動音")] public AudioClip tyuuMove;
    //[Tooltip("第ベタ移動音")] public AudioClip bigMove;
    //[Tooltip("打撃音")] public AudioClip attack;
    //[Tooltip("スタン音")] public AudioClip sutun;
    //[Tooltip("爆発音")] public AudioClip bom;
    //[Tooltip("吸う音")] public AudioClip inhale;
    //[Tooltip("吸い込んだ音")] public AudioClip Inhaled;
    //[Tooltip("噴射")] public AudioClip　injection;
    //[Header("ミニベタ")]


    //[Header("中ベタ")]
    //[Tooltip("触手が穴から出るとき")] public AudioClip tyuuout;
    //[Tooltip("触手が穴に入る時")] public AudioClip tyuuin;
    //[Tooltip("触手が倒れた時")] public AudioClip falldown;
    //[Tooltip("中ベタの穴が消える")] public AudioClip hole;

    //[Header("ステージ")]
    //[Tooltip("よごれが飛び散る")] public AudioClip scatter;
    //[Tooltip("現実が割れ始める")] public AudioClip crack;
    //[Tooltip("よごれで現実が割れる")] public AudioClip sbreak;

}
