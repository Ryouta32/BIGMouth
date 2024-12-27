using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 中ベタの当たり判定 */

public class NormalBetaCollision : MonoBehaviour
{
    [Tooltip("中ベタのアニメーターを付ける")]
    [SerializeField] Animator anim;
    [Tooltip("EnemyManagerのEnemyScriptを付ける")]
    [SerializeField] EnemyScript enemyScript;
    [Tooltip("NormalBetaManagerを付ける")]
    [SerializeField] NormalBetaManager normalBetaManager;


    private void Start()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Brush"))
        {
            if (normalBetaManager.colsignal)
            {
                normalBetaManager.colsignal = false;
                enemyScript.HitDamage();

                if (normalBetaManager.Children.Count > 1)
                {
                    AudioManager.manager.PlayPoint(AudioManager.manager.data.miniIn, this.gameObject);
                    anim.SetBool("Down", true);
                    enemyScript.data.sutnCount = enemyScript._data.sutnCount;
                }
                else
                {
                    normalBetaManager.colsignal = true;
                }
            }
        }
    }
}
