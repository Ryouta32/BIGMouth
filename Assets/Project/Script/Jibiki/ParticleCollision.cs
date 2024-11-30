using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* エフェクトの当たり判定 */

public class ParticleCollision : MonoBehaviour
{
    AudioManager audioM;

    bool audioflag;

    void Start()
    {
        audioM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioflag = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Brush"))
        {
            if(audioflag)
            {
                audioflag = false;
                audioM.PlayPoint(audioM.data.hole, this.gameObject);
            }
            Debug.Log("音鳴った");
            Destroy(transform.parent.gameObject, 0.4f);
        }
    }
}
