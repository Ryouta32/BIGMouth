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
            //Debug.Log("あたったよおおおおおおおおおおおおおおおおお");
            if (audioflag)
            {
                audioflag = false;
                AudioManager.manager.PlayPoint(AudioManager.manager.data.miniHole, this.gameObject);
            }
            transform.GetChild(0).gameObject.SetActive(false);
            //Debug.Log("音鳴った");
            Destroy(gameObject, 1f);
        }
    }
}
