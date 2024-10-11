using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public struct Konsekis
//{
//    [Tooltip("���Ղ̎�ނ����")] public EnemyData KonsekiData;
//    [Tooltip("���Ղ�^�����ۂ̍D���x�����")] public int like;
//}
[CreateAssetMenu]

public class EnemyData : ScriptableObject
{
    public enum State
    {
        general, escape, stun
    }
    [Tooltip("�X�^���܂ł̉�")] public float sutnCount;
    [Tooltip("�X�^���܂ł̉�")] public float sutnTime;
    [Tooltip("���A����")] public float returnTime;
    [Tooltip("�ړ����x")] public float speed;
    [Tooltip("���")] public State state;

    public EnemyData(EnemyData _data)
    {
        sutnCount = _data.sutnCount;
        sutnTime = _data.sutnTime;
        returnTime = _data.returnTime;
        speed = _data.speed;
        state = _data.state;
    }
}
