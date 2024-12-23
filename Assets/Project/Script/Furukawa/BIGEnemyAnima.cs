using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIGEnemyAnima : MonoBehaviour
{
    [SerializeField] BigEnemyScript bigSc;
    [SerializeField][Tooltip("上から順番に出てくる")] List<GameObject> Enemys;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Break()
    {
        bigSc.Spawn(Enemys[count]);
        count++;
    }
}
