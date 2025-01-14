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
    Vector3 tentaPos;
    Vector3 mushPos;
    OVRSceneManager ovrSceneManager;
    OVRScenePlane floor;

    private int count = 0;
    Animator anima;
    string DamageStr = "Damage";
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();
        //ルーム設定の読み込みが成功した時のコールバック登録
        //ovrSceneManager.SceneModelLoadedSuccessfully += onAnchorsLoaded;
        onAnchorsLoaded();
    }

    private void Update()
    {

        if (count >= 2)
        {
            bigSc.Erase();
        }
    }
    public void Break()
    {
        count++;
        anima.SetTrigger(DamageStr);

    }
    public void Damage()
    {
        anima.SetTrigger(DamageStr);
        //anima.SetTrigger(abareruStr);
    }

    public void fast()
    {
        Instantiate(tentacle, tentaPos, Quaternion.identity);
    }
    public void second()
    {
        Instantiate(mush, mushPos, Quaternion.identity);
    }
    public void thirdAttack()
    {
        third.Play();
    }
    public void thirdAttackStop()
    {
        third.Stop();
    }
    public void forthAttack()
    {
        forth.Play();
    }
    public void forthAttackStop()
    {
        forth.Stop();
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
