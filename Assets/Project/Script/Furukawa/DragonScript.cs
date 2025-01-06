using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{

    [SerializeField] Transform bigSpawnPos;
    [SerializeField] EnemyManager manager;
    [SerializeField] BetaSpawn spawn;

    public void Gamestart()
    {
        spawn.spawan();
        manager.GameStart();
    }
}
