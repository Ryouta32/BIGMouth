using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBrush : MonoBehaviour
{
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
                AudioManager.manager.PlayPoint(AudioManager.manager.data.ita, gameObject);
            }
            else if(count == 1)
            {
                AudioManager.manager.PlayPoint(AudioManager.manager.data.bokujyanai, gameObject);
            }

            count++;
        }
    }
}
