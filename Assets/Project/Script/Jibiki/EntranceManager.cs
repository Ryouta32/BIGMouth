using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* ドラゴンの登場をスクリプトで制御
 * 音を流してドラゴンのアニメーションさせる */

public class EntranceManager : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void AnimSet()
    {
        animator.SetTrigger("dragon_BreakIn_Take_001");
    }
}
