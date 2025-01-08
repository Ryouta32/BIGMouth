using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyScript : MonoBehaviour
{
    [SerializeField] List<GameObject> weekPoints;
    [Tooltip("弱点こする回数")][SerializeField] public int rubCount;
    [Tooltip("弱点から出る汚れの数")][SerializeField] public int dirtCount;
    [Tooltip("何回消せばよいか")][SerializeField] public int erasedCount;
    [SerializeField] EnemyData _data;
    [SerializeField] GameObject Tentacle;
    [SerializeField] GameObject Mush;
    [SerializeField] BIGEnemyAnima anima;
    [SerializeField] GameObject stunEffect;
    public BouSakiScript bouSaki;
    GameClearSC clearSC;
    private EnemyData data;
    private bool erase;
    private void Start()
    {
        clearSC = GameObject.Find("Clear").GetComponent<GameClearSC>();
        data = new EnemyData(_data);
    }
    private void Update()
    {
        transform.localPosition =new Vector3(0,0,0) ;
        transform.localEulerAngles = new Vector3(0, 0, 0);
        if (erase)
        {
            Vector3 diff = bouSaki.gameObject.transform.position - transform.position;
        if (diff.magnitude < bouSaki.GetInhaleDis() && bouSaki.GetInHale() && data.state == EnemyData.State.stun)
        {
            //吸い込みの処理

            bouSaki.StartOfSuction(transform.position - bouSaki.transform.position,true);
            //clearSC.Clear();
            Destroy(gameObject);

        }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (erase)
        {
            if (collision.gameObject.tag == "Brush")
            {
                    data.sutnCount--;
                    if (data.sutnCount <= 0)
                    {
                    //クリア演出
                    bouSaki.StartOfSuction(transform.position,true);
                    //clearSC.Clear();
                    }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (erase)
        {
            if (other.gameObject.tag == "Brush")
            {
                data.sutnCount--;
                if(data.state==EnemyData.State.stun)
                {
                    Destroy(gameObject);
                }    
                if (data.sutnCount <= 0)
                {
                    StartCoroutine("Stun");
                    //クリア演出
                    //clearSC.Clear();
                }
            }
        }
    }
    public void WeekBreak()
    {
        anima.Break();
    }
    public void Spawn(GameObject obj)
    {
        if (obj.name == "TentacleBeta")
            Instantiate(obj, EnemyManager.tentPos, Quaternion.identity);

        if (obj.name == "Mash")
            Instantiate(obj, EnemyManager.tentPos, Quaternion.identity);
    }
    IEnumerator Stun()//スタン中の処理
    {
        stunEffect.SetActive(true);
        Debug.Log("スタンエフェクト");
        AudioManager.manager.PlayPoint(AudioManager.manager.data.stun, this.gameObject, 3);
        yield return new WaitForSeconds(1f);
        data.state = EnemyData.State.stun;
        yield return new WaitForSeconds(data.sutnTime);
        data.state = EnemyData.State.general;
        data.sutnTime = _data.sutnTime;
        stunEffect.SetActive(false);
    }
    public void Erase() => erase = true;
    public void OBJScaleUP()
    {
        //erasedCount++;
        //erase = false;

        //StartCoroutine("ScaleUp");

    }
    public void OBJScaleDown()
    {
        //erasedCount--;
        //if (erasedCount == 0)
        //    erase = true;

        //StartCoroutine("ScaleDown");

    }
    //IEnumerator ScaleUp()
    //{
    //    //for (float i = 0; i < 0.005f; i += 0.001f)
    //    //{
    //    //    this.transform.localScale = new Vector3(this.transform.localScale.x + i, this.transform.localScale.x+ i, this.transform.localScale.x+ i);
    //    yield return new WaitForSeconds(0.1f);
    //    //}
    //}
    //IEnumerator ScaleDown()
    //{
    //    //for (float i = 0.005f; i > 0; i -= 0.001f)
    //    //{
    //    //    this.transform.localScale = new Vector3(this.transform.localScale.x - i, this.transform.localScale.x - i, this.transform.localScale.x - i);
    //    yield return new WaitForSeconds(0.1f);
    //    //}
    //}
}
