using UnityEngine;
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
    [Tooltip("タイプ")] public Type type;
    public EnemyData(EnemyData _data)
    {
        sutnCount = _data.sutnCount;
        sutnTime = _data.sutnTime;
        returnTime = _data.returnTime;
        speed = _data.speed;
        state = _data.state;
        type = _data.type;
    }

    public enum Type
    {
        dowo,slime,Tentacle,Mush,BIG
    }
}
