using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*壁エリア越えてきたらミミックオブジェクト表示させる*/

public class SetActiveScript : MonoBehaviour
{
    [SerializeField] GameObject mimic;

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
        if (collision.gameObject.CompareTag("Wall1"))
        {
            mimic.SetActive(true);
        }
    }
}
