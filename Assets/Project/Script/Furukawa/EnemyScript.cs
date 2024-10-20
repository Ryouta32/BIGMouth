using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    BetaLife betaLife;
    EnemyManager manager;
    public BouSakiScript bouSaki;
    [SerializeField] EnemyData _data;
    [SerializeField] GameObject stunEffect;
    [SerializeField] GameObject damageEffect;
    [SerializeField] GameObject DestroyEffect;
    private EnemyData data;
    float time=0;
    private void Start()
    {
        initialization();
        data = new EnemyData(_data);
    }
    private void Update()
    {
        Vector3 diff = bouSaki.gameObject.transform.position - transform.position;
        if (diff.magnitude < bouSaki.GetInhaleDis()&&bouSaki.GetInHale()&&data.state==EnemyData.State.stun)
        {
            //吸い込みの処理
            transform.position = Vector3.MoveTowards(transform.position, bouSaki.gameObject.transform.position, bouSaki.GetInHaleSpeed());
        }
        time += Time.deltaTime;
        if (time > data.returnTime)
            SetState(EnemyData.State.general);
    }
    public void initialization()
    {
        bouSaki = GameObject.Find("Stick").GetComponent<bouScript>().GetSaki();
        data = new EnemyData(_data);
        betaLife = GetComponent<BetaLife>();
    }
    private void OnDestroy()
    {
        Instantiate(DestroyEffect, transform.position, Quaternion.identity);
    }
    public void HitDamage()
    {
        time = 0;
        Debug.Log(data.state);

        Instantiate(damageEffect, transform.position, Quaternion.identity);
        //スタン状態なら消す
        if (data.state == EnemyData.State.stun)
        {
            destroyObj();
            Debug.Log("削除");
            Destroy(this.gameObject);
        }
        data.sutnCount--;
        if (data.sutnCount <= 0)
        {
            SetState(EnemyData.State.stun);
            StartCoroutine("Stun");
        }else
        SetState(EnemyData.State.escape);
    }
    IEnumerator Stun()//スタン中の処理
    {
        stunEffect.SetActive(true);
        yield return new WaitForSeconds(data.sutnTime);
        SetState(EnemyData.State.general);
        StunReturn();
        stunEffect.SetActive(false);
    }
    public void StunReturn() => data.sutnCount = _data.sutnCount;
    public void setManager(EnemyManager x) => manager = x;
    public void destroyObj() => manager.DestroyEnemys(this.gameObject);
    public void SetState(EnemyData.State sta)=>data.state = sta;
}
