using Es.InkPainter;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BouSakiScript : MonoBehaviour
{

    [SerializeField] bouScript bouSC;
    [SerializeField]
    private Brush brush;
    [SerializeField]
    private Brush draBrush;
    [SerializeField]
    private PaintManager.UseMethodType useMethodType = PaintManager.UseMethodType.RaycastHitInfo;
    [SerializeField]
    [Tooltip("チェックついてると消えます。ないと塗れます")]
    bool erase = false;
    [SerializeField]
    TextMeshProUGUI text;
    float time;
    [SerializeField] private OVRInput.RawButton actionBtn;
    [SerializeField] GameObject ShowerObj;
    [Header("噴射の塗り判定を都飛ばす強さ")]
    [SerializeField] float power;
    [Header("吸い込みの距離")]
    [SerializeField] float inHaleDis = 0.5f;
    [Header("吸い込み速度")]
    [SerializeField] float inHaleSpeed = 1;
    [Header("ドラゴンのタグ")]
    [SerializeField] string DragonTag = "Dragon";
    [Header("ごしごしエフェクト")]
    [SerializeField] GameObject ShineEffect;
    [Header("吸い込みエフェクト")]
    [SerializeField] GameObject SuctionObj;
    [Header("シャワーパワー")]
    [SerializeField] Slider slider;
    [SerializeField] GameClearSC clearSC;
    bool on=true;
   Vector3 hitpoint;
   public bool OnHale;
    float showerPoint = 1;
    [SerializeField] float showerLimit;
    [SerializeField] float showerThreshold;
    [SerializeField] float coolTime;
    [SerializeField] SpriteRenderer image;
    [SerializeField] Sprite InholeSp;
    [SerializeField] Sprite NoholeSp;
    private float cool;

    AudioSource source=new AudioSource();
    void Start()
    {
        hitpoint = Vector3.zero;
        slider.maxValue = showerLimit;
        showerPoint = showerThreshold;
        if (clearSC != null)
            clearSC = GameObject.Find("Clear").GetComponent<GameClearSC>();
    }

    void Update()
    {
        if (showerPoint >= showerLimit)
            showerPoint = showerLimit;
        slider.value = showerPoint;
        //showerPoint = 1; //デバッグ用
        //スキルの判定
        if (showerPoint > 0)
        {
            if (on && OVRInput.Get(actionBtn) || (on && Input.GetKey(KeyCode.Space)))
            {
                ShowerObj.SetActive(true);
                showerPoint -= Time.deltaTime * 10;
                StartCoroutine("ShowerTime");
            }
            if (OVRInput.GetUp(actionBtn) || Input.GetKeyUp(KeyCode.Space))
            {
                ShowerObj.SetActive(false);
                StopCoroutine("ShowerTime");
                on = true;
            }
        }

        if (cool > 0)
            cool -= Time.deltaTime;
        else
        {
            cool = 0;
            image.sprite = InholeSp;
            //s\吸い込み判定
            if (!OnHale &&( OVRInput.Get(OVRInput.RawButton.B) || Input.GetMouseButton(0)))
            {
                Inhale();
            }
        }
        if (OnHale&&( OVRInput.GetUp(OVRInput.RawButton.B) || Input.GetMouseButtonUp(0)))
        {
            UpInhale();
            image.sprite = NoholeSp;

            cool = coolTime;
        }
    }
    IEnumerator ShowerTime()
    {
        on = false;
        yield return new WaitForSeconds(0.2f);
        AudioManager.manager.PlayPoint(AudioManager.manager.data.cleanerSplash, this.gameObject);
        on = true;
    }
    private void Inhale()
    {
        OnHale = true;
        AudioManager.manager.PlayPoint(AudioManager.manager.data.cleanerSuction, this.gameObject);
    }
    private void UpInhale()
    {
        if (OnHale == false)
            return;
        OnHale = false;
        GetComponent<AudioSource>().Stop();
    }

    private void OnCollisionStay(Collision other)
    {
        Paint(other);
        time += Time.deltaTime;
        if (time > 0.8f)
        {
            time = 0;
            Instantiate(ShineEffect, transform.position, transform.rotation);
        }
    }
    private void OnCollisionExit(Collision col)
    {
        hitpoint = Vector3.zero;
        bouSC.ExisPos();
        //transform.rotation =  defaultQuaternion;
    }
    private void OnCollisionEnter(Collision collision)
    {
        PaintManager pManager = new PaintManager();
        Paint(collision);

        hitpoint = collision.contacts[0].point;
        bouSC.HitPos();
    }
    private void OnTriggerStay(Collider other)
    {
        Paint(other);


        time += Time.deltaTime;
        if (time > 0.8f)
        {
            time = 0;
            Instantiate(ShineEffect, transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Paint(other);



        hitpoint = other.ClosestPointOnBounds(this.transform.position);
        bouSC.HitPos();
    }
    private void OnTriggerExit(Collider other)
    {
        hitpoint = Vector3.zero;
        bouSC.ExisPos();
    }

    private void Paint(Collision other)
    {
        PaintManager pManager = new PaintManager();

        switch (other.transform.tag)
        {
            case "Dragon":
                pManager.Paint(other, useMethodType, !erase, draBrush, transform, true, DragonTag);
                Debug.Log("わあ");
                break;
            case "Wall":
                pManager.Paint(other, useMethodType, erase, brush, transform, true, DragonTag);
                break;
        }
    }
    private void Paint(Collider other)
    {
        PaintManager pManager = new PaintManager();

        switch (other.transform.tag)
        {
            case "Dragon":
                pManager.Paint(other, useMethodType, !erase, draBrush, transform, true, DragonTag);
                break;
            case "Wall":
                pManager.Paint(other, useMethodType, erase, brush, transform, true, DragonTag);
                break;
        }
    }
    public void StartOfSuction(Vector3 pos)
    {
        GameObject obj = Instantiate(SuctionObj, transform.position, Quaternion.identity);
        obj.GetComponent<SuikomiScript>().SetBousaki(this);
        ParticleSystem psy = obj.GetComponent<ParticleSystem>();
        var sh = psy.shape;

        sh.position = pos;
    }
    public void StartOfSuction(Vector3 pos,bool clear)
    {
        GameObject obj = Instantiate(SuctionObj, transform.position, Quaternion.identity);
        obj.GetComponent<SuikomiScript>().SetBousaki(this);
        ParticleSystem psy = obj.GetComponent<ParticleSystem>();
        var sh = psy.shape;

        sh.position = pos;
        if(clear)
        obj.GetComponent<SuikomiScript>().SetClear(clearSC);

    }
    public Vector3 GetHit() => hitpoint;
    public void SetHit(Vector3 x) => hitpoint = x;
    public float GetInhaleDis() => inHaleDis;
    public bool GetInHale() => OnHale;
    public float GetInHaleSpeed() => inHaleSpeed;
    public void AddShowerPoint(float x) => showerPoint += x;
}
