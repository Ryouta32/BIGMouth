using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIGEnemyChaildSC : MonoBehaviour
{
    public Vector3 destination;
    Vector3 vec;
    [Header("何秒で戻るか")]
    [SerializeField, Range(0, 10)]float time = 1;
    Vector3 velocity = Vector3.zero;
    bool move=false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GraSet");
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, time);
    }

    IEnumerator GraSet()
    {
        //Rigidbodyが邪魔なので物理関係を切ったのち移動開始。５秒は適当なので要調整
        yield return new WaitForSeconds(5f);
        vec=(destination-transform.position).normalized;
        if(GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().isKinematic=true;
        move = true;
    }
    public void WeekPoint()
    {
        StartCoroutine("ScaleUp");
    }
    IEnumerator ScaleUp()
    {
        for (float i = 1; i < 2; i += 0.1f)
        {
            this.transform.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator ScaleDown()
    {
        for (float i = 2; i > 1; i -= 0.1f)
        {
            this.transform.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
