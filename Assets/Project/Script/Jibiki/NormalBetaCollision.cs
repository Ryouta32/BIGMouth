﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 中ベタの当たり判定 */

public class NormalBetaCollision : MonoBehaviour
{
    [Tooltip("中ベタのアニメーターを付ける")]
    [SerializeField] Animator anim;
    [SerializeField] EnemyScript enemyScript;
    [Tooltip("NormalBetaManagerを付ける")]
    [SerializeField] NormalBetaManager normalBetaManager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brush"))
        {
            if (normalBetaManager.colsignal)
            {
                normalBetaManager.colsignal = false;
                enemyScript.HitDamage();
                //Debug.Log(enemyScript.data.sutnCount);

                if (normalBetaManager.Children.Count > 1)
                {
                    AudioManager.manager.PlayPoint(AudioManager.manager.data.tentacleIn, this.gameObject);
                    anim.SetBool("Down", true);
                    enemyScript.data.sutnCount = enemyScript._data.sutnCount;
                    if(enemyScript._data.sutnCount == 0)
                    {
                        anim.SetBool("Stun", true);
                    }
                }
                else
                {
                    normalBetaManager.colsignal = true;
                }
            }
        }
    }
}
