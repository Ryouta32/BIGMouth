using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyScript : MonoBehaviour
{
    [SerializeField] List<GameObject> weekPoints;
    [Tooltip("弱点こする回数")][SerializeField] public int rubCount;
    [Tooltip("弱点から出る汚れの数")][SerializeField] public int dirtCount;
    [Tooltip("何回消せばよいか")][SerializeField] public int erasedCount;
    [SerializeField] GameObject LookOnObj;
    [SerializeField] EnemyData _data;
    [SerializeField] GameObject Tentacle;
    [SerializeField] GameObject Mush;
    [SerializeField] BIGEnemyAnima anima;
    [SerializeField] GameObject stunEffect;
    [SerializeField] GameObject HitObject;
    public BouSakiScript bouSaki;
    [SerializeField] Renderer mainRender;
    Material mat;
    GameClearSC clearSC;
    public EnemyData data;
    private bool erase;
    float hagesisa = 0;
    private void Start()
    {
        mat = mainRender.material;
        data = new EnemyData(_data);
        clearSC = GameObject.Find("Clear").GetComponent<GameClearSC>();
        bouSaki = GameObject.Find("Stick").GetComponent<bouScript>().GetSaki();
        LookOnObj.SetActive(false);
    }
    private void Update()
    {
        transform.localPosition =new Vector3(0,0,0) ;
        transform.localEulerAngles = new Vector3(0, 0, 0);
        if (erase)
        {
            LookOnObj.SetActive(true);
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
    private void OnTriggerEnter(Collider other)
    {
        if (erase)
        {
            if (other.gameObject.tag == "Brush")
            {
                data.sutnCount--;
                hagesisa += 1f;
                Instantiate(HitObject, transform.position, Quaternion.identity);
                AudioManager.manager.PlayPoint(AudioManager.manager.data.damage, gameObject);
                mat.SetFloat("_hagesisa", hagesisa);
                if (data.state==EnemyData.State.stun)
                {
                    Destroy(gameObject);
                }    
                if (data.sutnCount <= 0)
                {
                    StartCoroutine("Stun");
                    //クリア演出
                    //clearSC.Clear();
                    bouSaki.StartOfSuction(transform.position, true);
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
    public BIGEnemyAnima GetAnima() => anima;
}
