using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempHaScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float abc;
        private float time;
    bool a;
    float b=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= abc)
        {
            time = 0;
            b *= -1;
        }

        transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y +( speed * b * Time.deltaTime), this.transform.localScale.z);
        Debug.Log(time);
        time += Time.deltaTime;
    }
}
