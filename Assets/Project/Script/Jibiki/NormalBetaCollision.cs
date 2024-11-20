using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 中ベタの当たり判定 */

public class NormalBetaCollision : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] EnemyScript enemyScript;
    NormalBetaManager normalBetaManager;

    private void Start()
    {
        normalBetaManager = transform.root.gameObject.GetComponent<NormalBetaManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Brush"))
        {
            //Debug.Log(normalBetaManager.Children.Count + "だよおおおおおおおおおおおおおおおおおおお");
            enemyScript.HitDamage();
            anim.SetBool("Down", true);
        }
    }
}
