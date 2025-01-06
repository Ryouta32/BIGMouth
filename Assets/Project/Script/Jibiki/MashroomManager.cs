using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* キノコベタのスクリプト */

public class MashroomManager : MonoBehaviour
{
    //[Tooltip("キノコブロックするときの間隔")]
    [SerializeField] float waittime;

    Animator anim;
    BoxCollider boxCollider;
    EnemyScript enemyScript;

    [Tooltip("音を再生するアニメーションの名前")]
    public string targetAnimationName;

    private bool isPlayingSound = false;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        enemyScript = gameObject.GetComponent<EnemyScript>();
        //InvokeRepeating(nameof(AnimProtection), repeattime, repeattime);
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(other.gameObject.CompareTag("shower") && stateInfo.IsName(targetAnimationName))
        {
            enemyScript.data.sutnCount = 0;
        }
        if (other.gameObject.CompareTag("Brush") && stateInfo.IsName(targetAnimationName))
        {
            enemyScript.HitDamage();
            StartCoroutine("AnimProtection");
        }
        else
        {
            //Debug.Log("なったーーーーーーーーーーーーーーーーーーーーーー");
            AudioManager.manager.PlayPoint(AudioManager.manager.data.mush, this.gameObject);
        }
    }

    IEnumerator AnimProtection()
    {
        anim.SetTrigger("Protection");
        yield return new WaitForSeconds(waittime);
        anim.SetTrigger("up");
    }
}
