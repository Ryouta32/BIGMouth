using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 壁エリア越えてきたらミミックオブジェクト表示させる */

public class SetActiveScript : MonoBehaviour
{
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
        if(other.gameObject.CompareTag("MIMIC"))
        {
            Debug.Log("atata");
            Renderer rnd = other.gameObject.GetComponent<Renderer>();

            rnd.enabled = true;
        }
    }
}
