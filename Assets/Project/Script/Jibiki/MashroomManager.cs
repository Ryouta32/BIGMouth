using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* キノコベタのスクリプト */

public class MashroomManager : MonoBehaviour
{
    [Tooltip("キノコブロックするときの間隔")]
    [SerializeField] float repeattime;

    Animator anim;
    BoxCollider boxCollider;
    EnemyScript enemyScript;
    AudioManager audioM;

    [Tooltip("音を再生するアニメーションの名前")]
    public string targetAnimationName;

    private bool isPlayingSound = false;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        enemyScript = gameObject.GetComponent<EnemyScript>();
        audioM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        InvokeRepeating(nameof(AnimProtection), repeattime, repeattime);
    }

    private void OnTriggerEnter(Collider other)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (other.gameObject.CompareTag("Brush") && stateInfo.IsName(targetAnimationName))
        {
            enemyScript.HitDamage();
        }
        else
        {
            Debug.Log("なったーーーーーーーーーーーーーーーーーーーーーー");
            audioM.PlayPoint(audioM.data.mush, this.gameObject);
        }
    }

    void AnimProtection()
    {
        //boxCollider.enabled = false;
        anim.SetTrigger("Protection");
    }

    void ProtectionEnd()
    {
        //boxCollider.enabled = true;
    }
}
