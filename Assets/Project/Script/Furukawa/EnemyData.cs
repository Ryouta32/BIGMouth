using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public struct Konsekis
//{
//    [Tooltip("痕跡の種類を入力")] public EnemyData KonsekiData;
//    [Tooltip("痕跡を与えた際の好感度を入力")] public int like;
//}
[CreateAssetMenu]

public class EnemyData : ScriptableObject
{
    public enum State
    {
        general, escape, stun
    }
    [Tooltip("スタンまでの回数")] public float sutnCount;
    [Tooltip("スタンまでの回数")] public float sutnTime;
    [Tooltip("復帰時間")] public float returnTime;
    [Tooltip("移動速度")] public float speed;
    [Tooltip("状態")] public State state;

    public EnemyData(EnemyData _data)
    {
        sutnCount = _data.sutnCount;
        sutnTime = _data.sutnTime;
        returnTime = _data.returnTime;
        speed = _data.speed;
        state = _data.state;
    }
}
