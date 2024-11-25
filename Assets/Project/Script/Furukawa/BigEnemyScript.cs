using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyScript : MonoBehaviour
{
    [SerializeField] List<GameObject> weekPoints;
    [Tooltip("弱点こする回数")][SerializeField] public int rubCount;
    [Tooltip("弱点から出る汚れの数")][SerializeField] public int dirtCount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
