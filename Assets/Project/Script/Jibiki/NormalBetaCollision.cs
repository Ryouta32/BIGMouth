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
            //残りのスポーン地の数
            //Debug.Log(normalBetaManager.Children.Count + "だよおおおおおおおおおおおおおおおおおおお");
            //Debug.Log("normalBetaManager.colsignal：" + normalBetaManager.colsignal);

            //HitDamageは一回きりで呼び出す
            if (normalBetaManager.colsignal)
            {
                //Debug.Log("呼ばれた");
                normalBetaManager.colsignal = false;
                enemyScript.HitDamage();

                if (normalBetaManager.Children.Count > 1)
                {
                    anim.SetBool("Down", true);
                    enemyScript.data.sutnCount = enemyScript._data.sutnCount;
                }
                else
                {
                    //normalBetaManager.colsignal = true;
                }
                //Debug.Log("のち：" + normalBetaManager.colsignal);
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Brush"))
        {
            if(normalBetaManager.Children.Count <= 1)
            {
                normalBetaManager.colsignal = true;
            }
        }
    }
}
