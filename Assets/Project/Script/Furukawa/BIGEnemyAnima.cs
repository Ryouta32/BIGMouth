using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//それぞれのTrigger
//Damage
public class BIGEnemyAnima : MonoBehaviour
{
    [SerializeField] BigEnemyScript bigSc;
    [SerializeField] GameObject tentacle;
    [SerializeField] GameObject mush;
    [SerializeField] ParticleSystem third;
    [SerializeField] ParticleSystem forth;
    [SerializeField] int weekCount;
    [SerializeField] GameObject week;
    [SerializeField] Transform[] weekPos;

    [SerializeField] GameObject lightLine;
    [SerializeField] GameObject DestroyEffect;
    [SerializeField] Renderer mainRender;
    Material mat;
    Vector3 tentaPos;
    Vector3 mushPos;
    OVRScenePlane floor;
    GameObject tentaObj;
    GameObject mushObj;
    bool tentakill = false;
    bool mushkill = false;
    int count = 0;
    Animator anima;
    string DamageStr = "Damage";
    [SerializeField] GameObject ball;
    bool[] bossDamage =new bool[4];
    GameObject ballObj;

    GameObject Dragonvoice;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<bossDamage.Length;i++)
            bossDamage[i] = true;
        anima = GetComponent<Animator>();
        mat = mainRender.material;
        onAnchorsLoaded();

        Dragonvoice = GameObject.Find("DragonVoice");
    }

    private void Update()
    {

        if (count >= weekCount && bossDamage[3])
        {
            bossDamage[3] = false;
            mat.SetFloat("_hagesisa", 5f);
            ballObj.GetComponent<BIGBallDestroy>().SetHagesisa(5.8f);
            bigSc.Erase();
            StartCoroutine("Clear");
        }
        if(count>= weekCount - 1 && bossDamage[2])
        {
            bossDamage[2] = false;
            mat.SetFloat("_hagesisa", 3.5f);
            ballObj = Instantiate(ball,transform.position,Quaternion.identity,transform);
            ballObj.GetComponent<BIGBallDestroy>().SetHagesisa(7);
            ballObj.GetComponent<BIGBallDestroy>().SetBIG(bigSc);
            Instantiate(DestroyEffect,transform.position,Quaternion.identity,transform);
        }
        if (count >= weekCount - 2 && bossDamage[1])
        {
            bossDamage[1] = false;
            mat.SetFloat("_hagesisa", 2f);

        }
        if (count >= weekCount - 3 && bossDamage[0])
        {
            bossDamage[0] = false;
            mat.SetFloat("_hagesisa", 1f);
        }

        if (tentakill && tentaObj == null)
        {
            tentakill = false;
            bigSc.SetInvincible(false);
            bigSc.GetAnima().anima.SetTrigger("kill");
        }
        if (mushkill && mushObj == null)
        {
            mushkill = false;
            bigSc.SetInvincible(false);
            bigSc.GetAnima().anima.SetTrigger("kill");
            for (int i = 0; i < weekPos.Length; i++)
            {
                GameObject obj = Instantiate(week, weekPos[i].position, Quaternion.identity, weekPos[i]);
                obj.GetComponent<BIGEnemyWeekPoint>().SetBig(bigSc);
            }
        }
    }
    public void Break()
    {
        count++;
        anima.SetTrigger(DamageStr);

    }
    public void WeekAudio()
    {
        //AudioManager.manager.Play(AudioManager.manager.data.weekAnnounce);
    }
    public void KillAudio()
    {
        //AudioManager.manager.Play(AudioManager.manager.data.killAnnounce);
    }
    IEnumerator Clear()
    {
        yield return new WaitForSeconds(3f);
        bigSc.Clear();
    }
    public void fast()
    {
        tentaObj = Instantiate(tentacle, tentaPos, Quaternion.identity);
        GameObject obj = Instantiate(lightLine,new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z), Quaternion.identity,tentaObj.transform);
        obj.GetComponent<lightLine>().setPos( tentaPos - transform.position );
        tentaObj.GetComponent<tentacleLine>().SetLine(obj.GetComponent<lightLine>());
        tentakill = true;
        Dragonvoice.SetActive(true);
    }
    public void second()
    {
        mushObj = Instantiate(mush, mushPos, Quaternion.identity);
        GameObject obj = Instantiate(lightLine, new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z), Quaternion.identity,mushObj.transform);
        obj.GetComponent<lightLine>().setPos( mushPos - transform.position );
        //ParticleSystem ps = obj.GetComponent<ParticleSystem>();
        //var sp = ps.shape;
        //sp.position = transform.position;
        mushkill = true;
    }
    public void thirdAttack()
    {
        //third.Play();
    }
    public void thirdAttackStop()
    {
        //third.Stop();
    }
    public void forthAttack()
    {
        forth.Play();
    }
    public void forthAttackStop()
    {
        forth.Stop();
    }
    public void Invincible()
    {
        bigSc.SetInvincible(false);
    }
    void onAnchorsLoaded()
    {
        //OVRSceneRoomの参照取得
        OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();

        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);
        float y = 0;
        floor = sceneRoom.Floor;
        float posy = floor.transform.position.y;
        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.Bed))
            {
                tentaPos = classification.transform.position;
            }
            if (classification.Contains(OVRSceneManager.Classification.Lamp))
            {
                mushPos = classification.transform.position;
            }
        }
        tentaPos.y = posy;
        mushPos.y = posy;
    }
}
