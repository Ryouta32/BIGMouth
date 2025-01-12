using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaLife : MonoBehaviour
{
    EnemyScript enemySC;

    private void Start()
    {
        enemySC = GetComponent<EnemyScript>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Brush"))
        {
            enemySC.HitDamage();
        }
    }
}
