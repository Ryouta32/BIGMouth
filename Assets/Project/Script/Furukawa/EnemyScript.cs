using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    BetaLife betaLife;
    EnemyManager manager;

    private void Start()
    {
        GetComponent<BetaLife>();
    }

    public void setManager(EnemyManager x) => manager = x;
    public void destroyObj() => manager.DestroyEnemys(this.gameObject);
}
