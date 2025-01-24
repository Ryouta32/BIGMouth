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

    [SerializeField] float repeattime;

    AnimatorStateInfo stateInfo;

    public static bool mushflag;

    BoxCollider box;

    void Start()
    {
        mushflag = true;
        box = gameObject.GetComponent<BoxCollider>();
        anim = gameObject.GetComponent<Animator>();
        enemyScript = gameObject.GetComponent<EnemyScript>();

        InvokeRepeating(nameof(mushsound), repeattime, repeattime);
    }

    private void Update()
    {
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (!stateInfo.IsName("Idle"))
        {
            box.enabled = false;
        }
        else
        {
            box.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brush") && stateInfo.IsName("Idle"))
        {
            if(mushflag)
            {
                StartCoroutine("AnimProtection");
                //Idleモーションの時にブラシが当たったとき
                enemyScript.HitDamage();
                mushflag = false;
            }
        }
    }

    IEnumerator AnimProtection()
    {
        anim.SetTrigger("Protection");
        yield return new WaitForSeconds(waittime);
        anim.SetTrigger("up");
        mushflag = true;
    }

    void mushsound()
    {
        AudioManager.manager.PlayPoint(AudioManager.manager.data.mushidle, this.gameObject);
    }
}
