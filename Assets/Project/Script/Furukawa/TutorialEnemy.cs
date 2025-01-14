using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    [SerializeField] GameObject stunEffect;
    [SerializeField] GameObject DestroyEffect;
    [SerializeField] public EnemyData _data;
    [SerializeField] GameObject damageEffect;
    public BouSakiScript bouSaki;
    private EnemyData data;
    private tutorialScript tutorialSC;
    bool inHale;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        data = new EnemyData(_data);
        bouSaki = GameObject.Find("Stick").GetComponent<bouScript>().GetSaki();
        tutorialSC = GameObject.Find("tutorial").GetComponent<tutorialScript>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 diff = bouSaki.gameObject.transform.position - transform.position;
        if (diff.magnitude < bouSaki.GetInhaleDis() && bouSaki.GetInHale() && data.state == EnemyData.State.stun)
        {
            //吸い込みの処理

            bouSaki.StartOfSuction(transform.position - bouSaki.transform.position,data.type);
            inHale = true;
            //成功アナウンスに変える
            AudioSource.PlayClipAtPoint(AudioManager.manager.data.damage, this.gameObject.transform.position);
            tutorialSC.CLEAR();
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(data.sutnCount);
        if (collision.gameObject.CompareTag("Brush"))
        {
            AudioManager.manager.PlayPoint(AudioManager.manager.data.kill, this.gameObject);
            GameObject clone = Instantiate(damageEffect, transform.position, Quaternion.identity);
            Destroy(clone, 1.0f);
            //スタン状態なら消す
            if (data.state == EnemyData.State.stun)
            {
                //失敗アナウンスに変える
                //AudioSource.PlayClipAtPoint(AudioManager.manager.data.miniBom, this.gameObject.transform.position);
                tutorialSC.Retry();
                anim.SetFloat("Speed", 1);
                Debug.Log("しっぱい！");
                Destroy(this.gameObject);
            }
            else
            {
                data.sutnCount--;
            }

        }
    }
    IEnumerator Stun()//スタン中の処理
    {
        anim.SetFloat("Speed", 0);
        stunEffect.SetActive(true);
        AudioManager.manager.PlayPoint(AudioManager.manager.data.stun, this.gameObject);

        yield return new WaitForSeconds(1.0f);
        SetState(EnemyData.State.stun);
        yield return new WaitForSeconds(data.sutnTime );

        SetState(EnemyData.State.general);
        stunEffect.SetActive(false);
        anim.SetFloat("Speed", 1);
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("mi-");
        if (data.sutnCount <= 0)
        {
            StunReturn();
            StartCoroutine("Stun");
        }
        else
            SetState(EnemyData.State.escape);
    }
    private void OnDestroy()
    {
        //Destroy(DestroyEffect, 5);
        if (!inHale)
            Instantiate(DestroyEffect, transform.position, Quaternion.identity);
    }
    public void StunReturn() => data.sutnCount = _data.sutnCount;

    public void SetState(EnemyData.State sta)=>data.state = sta;
    public void SetTutorial(tutorialScript sc) => tutorialSC = sc;
}
