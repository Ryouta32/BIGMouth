using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIGEnemyChaildSC : MonoBehaviour
{
    public Vector3 destination;
    [HideInInspector]public BigEnemyScript biSC;
    Vector3 vec;
    [Header("何秒で戻るか")]
    [SerializeField, Range(0, 10)]float time = 1;
    [SerializeField] EnemyData _data;
    private EnemyData data;
    private BouSakiScript bouSaki;

    Vector3 velocity = Vector3.zero;
    bool move=false;
    float dis;
    // Start is called before the first frame update
    void Start()
    {
        data = new EnemyData(_data);
        bouSaki = GameObject.Find("Stick").GetComponent<bouScript>().GetSaki();
        StartCoroutine("GraSet");
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, time);
            dis = Vector3.Distance(transform.position, destination);
            if (dis <= 1) { 
                if (biSC != null)
                {
                    biSC.OBJScaleUP();
                    Destroy(this.gameObject);
                }
            }
            Vector3 diff = bouSaki.gameObject.transform.position - transform.position;
            if (diff.magnitude < bouSaki.GetInhaleDis() && bouSaki.GetInHale() )
            {
                //吸い込みの処理

                bouSaki.StartOfSuction(transform.position - bouSaki.transform.position);
                Destroy(this.gameObject);
            }
        }
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
    private void OnCollisionEnter(Collision collision)
    {
        data.sutnCount--;
        if (data.sutnCount <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
