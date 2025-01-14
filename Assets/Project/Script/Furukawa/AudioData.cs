using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class AudioData : ScriptableObject
{
    public struct AudioSouceItem
    {
       public AudioSource souce;
       public int loopCoun;
    }
    [Header("ベタ関係")]
    [Tooltip("あるく")] public AudioClip move;
    [Tooltip("だめーじ")] public AudioClip damage;
    [Tooltip("やられる")] public AudioClip kill;
    [Tooltip("スタン")] public AudioClip stun;

    [Header("中ベタ")]
    [Tooltip("中ベタ爆発")] public AudioClip normalBom;
    [Tooltip("触手ぶくぶく")] public AudioClip bukubuku;
    [Tooltip("触手出現")] public AudioClip tentacleOut;
    [Tooltip("触手逃げる")] public AudioClip tentacleIn;
    [Tooltip("触手ベタん")] public AudioClip tentacleBetan;
    [Tooltip("触手穴ふさぎ")] public AudioClip tentacleHole;
    [Tooltip("キノコポタん")] public AudioClip mushPotan;
    [Tooltip("攻撃")] public AudioClip attack;
    [Tooltip("キノコかさ")] public AudioClip mushKasa;

    [Header("大ベタ")]
    [Tooltip("大ベタ爆発")] public AudioClip bigBom;
    [Tooltip("大ベタ出現")] public AudioClip bigArrival;
    [Tooltip("危険です")] public AudioClip emergency;

    [Header("掃除機")]
    [Tooltip("きゅきゅ")] public AudioClip clean;
    [Tooltip("チャージ")] public AudioClip charge;
    [Tooltip("吸い込み")] public AudioClip suction;
    [Tooltip("バブル")] public AudioClip bubble;
    [Tooltip("C-5")] public AudioClip cleaner5;
    [Tooltip("シャワー")] public AudioClip shower;
    [Tooltip("C-7 fix")] public AudioClip cleanerFix;

    [Header("ステージ")]
    [Tooltip("S-5 emergency")] public AudioClip stageEnergency;
    [Tooltip("S-6 emergency2")] public AudioClip stageEnergency2;

    [Header("システム")]
    [Tooltip("Aぼたん")] public AudioClip Abutton;
    [Tooltip("Bぼたん")] public AudioClip Bbutton;
    [Tooltip("stage")] public AudioClip systemStage;
    [Tooltip("pointer")] public AudioClip systemPointer;

    [Header("BGM")]
    [Tooltip("MainBGM")] public AudioClip mainBGM;
    [Tooltip("チュートリアル")] public AudioClip tutorialBGM;
    [Tooltip("クリア")] public AudioClip clearBGM;
    [Tooltip("ゲームオーバー")] public AudioClip gameoverBGM;
    [Tooltip("ボス")] public AudioClip bossBGM;

    [Header("ボイス")]
    [Tooltip("たすけて")] public AudioClip help;
    [Tooltip("あ、、、せかいがわれてしまった")] public AudioClip worldBreak;
    [Tooltip("せかいが割れそうだよー")] public AudioClip worldBreakAbout;
    [Tooltip("よごれおとしてー")] public AudioClip yogoreWash;
    [Tooltip("ひびがはいったら")] public AudioClip crack;
    [Tooltip("アナウンス")] public AudioClip announce;
    [Tooltip("あと少し")]public AudioClip littleMore;
    [Tooltip("チュートリアル完了")] public AudioClip TutorialClear;

    [Header("その他音源")]
    [Tooltip("壁ぶつかり")] public AudioClip wallTackle;
    [Tooltip("壁破壊")] public AudioClip wallBreak;
    [Tooltip("デバッグ用")] public AudioClip debug;

}
