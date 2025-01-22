using Es.InkPainter;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

enum rotate
{
    ue, sita, naname, gyakunaname
}
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
    [SerializeField] private OVRInput.RawButton showerBtn;
    [SerializeField] ParticleSystem ShowerObj;
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
    [SerializeField] GameObject SuctionTentacleObj;
    [SerializeField] GameObject SuctionMushObj;
    [SerializeField] GameObject SuctionBIGObj;
    [SerializeField] GameObject InHoleObj;
    [Header("シャワーパワー")]
    [SerializeField] Slider slider;
    [SerializeField] GameClearSC clearSC;
    bool on = true;
    Vector3 hitpoint;
    public bool OnHale;
    float showerPoint = 1;
    [SerializeField] float showerLimit;
    [SerializeField] float showerThreshold;
    [SerializeField] float coolTime;
    [SerializeField] SpriteRenderer image;
    [SerializeField] Sprite InholeSp;
    [SerializeField] Sprite NoholeSp;
    [SerializeField] float inHoleTime;
    private float cool;
    [SerializeField] Sprite[] brushPaints;

    [SerializeField] GameObject yogosi;
    [SerializeField] float showerSpeed = 10;
    void Start()
    {
        hitpoint = Vector3.zero;
        slider.maxValue = showerLimit;
        showerPoint = showerThreshold;
        InHoleObj.SetActive(false);
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
                ShowerObj.Play();
                showerPoint -= Time.deltaTime * showerSpeed;
                StartCoroutine("ShowerTime");
            }
        }
        else
            ShowerStop();

        if (OVRInput.GetUp(actionBtn) || Input.GetKeyUp(KeyCode.Space))
        {
            ShowerStop();
        }
        cool = 0;
        image.sprite = InholeSp;
        //s\吸い込み判定
        if (OVRInput.Get(showerBtn) || Input.GetMouseButton(0))
        {
            OnHale = true;
            Inhale();
        }
        if (OVRInput.GetUp(showerBtn))
            UpInhale();
    }
    IEnumerator ShowerTime()
    {
        on = false;
        yield return new WaitForSeconds(0.2f);
        AudioManager.manager.PlayPoint(AudioManager.manager.data.shower, this.gameObject);
        on = true;
    }
    private void ShowerStop()
    {
        ShowerObj.Stop();
        StopCoroutine("ShowerTime");
        AudioManager.manager.StopPoint(gameObject);
        on = true;
    }
    private void Inhale()
    {
        if (GetComponent<AudioSource>())
        {
            if (!GetComponent<AudioSource>().isPlaying)
                AudioManager.manager.PlayPoint(AudioManager.manager.data.suction, this.gameObject);
        }
        else
                AudioManager.manager.PlayPoint(AudioManager.manager.data.suction, this.gameObject);
        InHoleObj.SetActive(true);
        //StartCoroutine("UpInhale");
    }
    private void UpInhale()
    {
        //yield return new WaitForSeconds(inHoleTime);
        OnHale = false;
        InHoleObj.SetActive(false);
        GetComponent<AudioSource>().Stop();
        //image.sprite = NoholeSp;
        //cool = coolTime;
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
        //yogosi.SetActive(true);
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
        //brush.BrushTexture = (Texture)CheckPaintTex();
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
    private Sprite CheckPaintTex()
    {
        float rotateZ = transform.root.localRotation.z;

        if (rotateZ > 0 && rotateZ < 45)
            return brushPaints[(int)rotate.sita];
        if (rotateZ > 45 && rotateZ < 90)
            return brushPaints[(int)rotate.gyakunaname];
        if (rotateZ > 90 && rotateZ < 135)
            return brushPaints[(int)rotate.naname];
        if (rotateZ > 135 && rotateZ < 180)
            return brushPaints[(int)rotate.ue];

        return brushPaints[0];
    }
    //public void StartOfSuction(Vector3 pos)
    //{
    //    GameObject obj = Instantiate(SuctionObj, transform.position, Quaternion.identity);
    //    obj.GetComponent<SuikomiScript>().SetBousaki(this);
    //    ParticleSystem psy = obj.GetComponent<ParticleSystem>();
    //    var sh = psy.shape;

    //    sh.position = pos;
    //}
    public void StartOfSuction(Vector3 pos, EnemyData.Type type)
    {
        GameObject suction;
        switch (type)
        {
            case EnemyData.Type.dowo:
            case EnemyData.Type.slime:
                suction = SuctionObj;
                break;
            case EnemyData.Type.Tentacle:
                suction = SuctionTentacleObj;
                break;
            case EnemyData.Type.Mush:
                suction = SuctionMushObj;
                break;
            case EnemyData.Type.BIG:
                suction = SuctionBIGObj;
                break;

            default:
                suction = SuctionObj;
                break;
        }
        GameObject obj = Instantiate(suction, transform.position, Quaternion.identity);
        obj.GetComponent<SuikomiScript>().SetBousaki(this);
        ParticleSystem psy = obj.GetComponent<ParticleSystem>();
        var sh = psy.shape;

        sh.position = pos;
    }
    public void StartOfSuction(Vector3 pos, bool clear)
    {
        GameObject obj = Instantiate(SuctionObj, transform.position, Quaternion.identity);
        obj.GetComponent<SuikomiScript>().SetBousaki(this);
        ParticleSystem psy = obj.GetComponent<ParticleSystem>();
        var sh = psy.shape;

        sh.position = pos;

        if (clear && clearSC != null)
            obj.GetComponent<SuikomiScript>().SetClear(clearSC);

    }
    public Vector3 GetHit() => hitpoint;
    public void SetHit(Vector3 x) => hitpoint = x;
    public float GetInhaleDis() => inHaleDis;
    public bool GetInHale() => OnHale;
    public float GetInHaleSpeed() => inHaleSpeed;
    public void AddShowerPoint(float x) => showerPoint += x;
    public float GetCool() => cool / coolTime;
}
