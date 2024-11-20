using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* エフェクトの当たり判定 */

public class ParticleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Brush"))
        {
            //Debug.Log("エフェクトに当たった");
            Destroy(transform.parent.gameObject);
        }
    }
}
