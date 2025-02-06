using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBrush : MonoBehaviour
{
    int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Brush"))
        {
            if(count > 1)
            {
                count = 0;
            }
            if(count == 0)
            {
                AudioManager.manager.PlayPoint(AudioManager.manager.data.ita, gameObject, 2);
            }
            else if(count == 1)
            {
                AudioManager.manager.PlayPoint(AudioManager.manager.data.bokujyanai, gameObject, 2);
            }

            count++;
        }
    }
}
