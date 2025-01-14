﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* エフェクトの当たり判定 */

public class ParticleCollision : MonoBehaviour
{
    bool audioflag;
    [SerializeField] Animator anim;

    void Start()
    {
        audioflag = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (other.gameObject.CompareTag("Brush") && stateInfo.IsName("Base"))
        {
            if (audioflag)
            {
                audioflag = false;
                AudioManager.manager.PlayPoint(AudioManager.manager.data.tentacleHole, this.gameObject);
            }
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
    }
}
