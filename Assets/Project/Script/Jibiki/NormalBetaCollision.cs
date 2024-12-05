using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 中ベタの当たり判定 */

public class NormalBetaCollision : MonoBehaviour
{
    [Tooltip("触手ベタのアニメーターを付ける")]
    [SerializeField] Animator anim;
    [Tooltip("EnemyManagerのEnemyScriptを付ける")]
    [SerializeField] EnemyScript enemyScript;
    [Tooltip("NormalBetaManagerを付ける")]
    [SerializeField] NormalBetaManager normalBetaManager;

    AudioManager audioM;

    private void Start()
    {
        audioM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
                    audioM.PlayPoint(audioM.data.tyuuin, this.gameObject);
                    anim.SetBool("Down", true);
                    enemyScript.data.sutnCount = enemyScript._data.sutnCount;

                }
                else
                {
                    normalBetaManager.colsignal = true;
                }
            }
            else
            {
                return;
            }
        }
    }
}
