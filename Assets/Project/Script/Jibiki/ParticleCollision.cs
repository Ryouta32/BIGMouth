using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* エフェクトの当たり判定 */

public class ParticleCollision : MonoBehaviour
{
    bool audioflag;

    void Start()
    {
        audioflag = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Brush"))
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
