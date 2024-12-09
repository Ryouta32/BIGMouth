using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* キノコベタのスクリプト */

public class MashroomManager : MonoBehaviour
{
    [SerializeField] Animator anim;

    [SerializeField] BoxCollider boxCollider;

    [Tooltip("EnemyManagerのEnemyScriptを付ける")]
    [SerializeField] EnemyScript enemyScript;

    [SerializeField] float repeattime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(AnimProtection), repeattime, repeattime);
    }

    // Update is called once per frame
    void Update()
    {
        
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
