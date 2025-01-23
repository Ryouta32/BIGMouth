using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* キノコベタのスクリプト */

public class MushroomManager1 : MonoBehaviour
{
    [Tooltip("しゃがむときの秒数")]
    [SerializeField] float waittime;

    Animator anim;
    EnemyScript enemyScript;

    [SerializeField] float repeattime;

    AnimatorStateInfo stateInfo;

    BoxCollider box1;

    void Start()
    {
        box1 = gameObject.GetComponent<BoxCollider>();
        anim = gameObject.transform.root.GetComponent<Animator>();
        enemyScript = gameObject.transform.root.GetComponent<EnemyScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (other.gameObject.CompareTag("Brush") && stateInfo.IsName("Idle"))
        {
            if (MushroomManager.mushflag)
            {
                StartCoroutine("AnimProtection");
                //Idleモーションの時にブラシが当たったとき
                enemyScript.HitDamage();
                MushroomManager.mushflag = false;
            }
        }
        else if (other.gameObject.CompareTag("shower") && stateInfo.IsName("Idle"))
        {
            //Idleモーションの時にシャワーが当たったとき
            enemyScript.data.sutnCount = 0;
        }
        else if (other.gameObject.CompareTag("Brush"))
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
        MushroomManager.mushflag = true;
    }
}
