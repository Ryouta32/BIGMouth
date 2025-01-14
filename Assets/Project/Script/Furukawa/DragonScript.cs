using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{

    [SerializeField] Transform bigSpawnPos;
    [SerializeField] EnemyManager manager;
    [SerializeField] BetaSpawn spawn;
    [SerializeField] GameObject TentSeki;
    [SerializeField] GameObject MushSeki;
    [SerializeField] Transform Cough;
    [SerializeField] float power;
    public void Gamestart()
    {
        spawn.spawan();
        manager.GameStart();
    }
    public void TentacleCough()
    {
        GameObject obj = Instantiate(TentSeki, Cough.position, Quaternion.Euler(0, 180, 0));
    }
    public void MushCough()
    {
        GameObject obj = Instantiate(MushSeki, Cough.position, Quaternion.Euler(0, 180, 0));
    }
}
