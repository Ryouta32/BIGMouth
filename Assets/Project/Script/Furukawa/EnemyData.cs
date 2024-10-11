using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Konsekis
{
    [Tooltip("���Ղ̎�ނ����")] public EnemyData KonsekiData;
    [Tooltip("���Ղ�^�����ۂ̍D���x�����")] public int like;
}
[CreateAssetMenu]

public class EnemyData : ScriptableObject
{
    public enum State
    {
        general, escape, stun
    }
    [Tooltip("�X�^���܂ł̉�")] public int sutnCount;
    [Tooltip("�ړ����x")] public float speed;
    [Tooltip("���")] public State state;
}
