using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 中ベタの当たり判定 */

public class NormalBetaCollision : MonoBehaviour
{
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ブラシに当たったら
        if (collision.gameObject.CompareTag("Brush"))
        {
            anim.SetBool("Down", true);
            Debug.Log("ブラシが当たったよ");
        }
    }
}
