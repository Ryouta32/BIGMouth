using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{

    [SerializeField] Transform bigSpawnPos;

    private void Start()
    {
        GameObject.Find("EnemyManager").GetComponent<EnemyManager>().SetBossPos(bigSpawnPos);
    }
}
