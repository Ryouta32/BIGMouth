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

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        enemyScript = gameObject.GetComponent<EnemyScript>();
        InvokeRepeating(nameof(AnimProtection), repeattime, repeattime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brush"))
        {
            enemyScript.HitDamage();
        }
    }

    void AnimProtection()
    {
        boxCollider.enabled = false;
        anim.SetTrigger("Protection");
    }

    void ProtectionEnd()
    {
        boxCollider.enabled = true;
    }
}
