using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* キノコベタのスクリプト */

public class MushroomManager : MonoBehaviour
{
    [Tooltip("しゃがむときの秒数")]
    [SerializeField] float waittime;

    Animator anim;
    EnemyScript enemyScript;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        enemyScript = gameObject.GetComponent<EnemyScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (other.gameObject.CompareTag("shower") && stateInfo.IsName("Idle"))
        {
            //Idleモーションの時にシャワーが当たったとき
            enemyScript.data.sutnCount = 0;
        }
        else if (other.gameObject.CompareTag("Brush") && stateInfo.IsName("Idle"))
        {
            //Idleモーションの時にブラシが当たったとき
            enemyScript.HitDamage();
            Debug.Log(enemyScript.data.sutnCount + "だよｙｙｙｙｙｙｙｙ");

            StartCoroutine("AnimProtection");
        }
        else if(other.gameObject.CompareTag("Brush"))
        {
            //防御してるときの音再生
            AudioManager.manager.PlayPoint(AudioManager.manager.data.mushKasa, this.gameObject);
        }
    }

    IEnumerator AnimProtection()
    {
        anim.SetTrigger("Protection");
        yield return new WaitForSeconds(waittime);
        anim.SetTrigger("up");
    }
}
