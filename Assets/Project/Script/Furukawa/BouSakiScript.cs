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
    float pontime = 0;
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
    [SerializeField] Slider sliderLight;
    [SerializeField] GameClearSC clearSC;
    [SerializeField] Image showerUILight;
    [SerializeField] Vector3 showerUIScale;
    [SerializeField] Vector3 defaultShowerUIScale;
    [SerializeField] GameObject lightLine;
    [SerializeField] Transform lineEndTra;
    [SerializeField] Transform lineStartTra;
    bool on = true;
    Vector3 hitpoint;
    public bool OnHale;
    public float showerPoint = 1;
    [Header("シャワーパワーの上限")]
    [SerializeField] float showerLimit;
    [Header("シャワーパワーの初期値")]
    [SerializeField] float showerThreshold;
    [Header("床壁をこすった時の回復量")]
    [SerializeField] float showerHeelPower;
    //[SerializeField] float coolTime;
    [SerializeField] SpriteRenderer image;
    [SerializeField] Sprite InholeSp;
    [SerializeField] Sprite NoholeSp;
    [SerializeField] float inHoleTime;
    //private float cool;
    [SerializeField] Sprite[] brushPaints;

    [SerializeField] GameObject yogosi;
    [SerializeField] float showerSpeed = 10;
    float ShowerPointVal = 0;
    bool showerOn;
    void Start()
    {
        hitpoint = Vector3.zero;
        slider.maxValue = showerLimit;
        sliderLight.maxValue = showerLimit;
        showerPoint = showerThreshold;
        sliderLight.maxValue = showerLimit;
        slider.value = showerPoint;
    }

    void Update()
    {
        if (showerPoint >= showerLimit)
            showerPoint = showerLimit;
        if (ShowerPointVal >= showerLimit)
            ShowerPointVal = showerLimit;
        if (showerPoint <= 0)
            showerPoint = -0.1f;
        if (ShowerPointVal <= 0)
            ShowerPointVal = -0.1f;

        if (slider.value + 0.1f < showerPoint)
        {
            showerUILight.gameObject.SetActive(true);
            slider.transform.localScale = Vector3.Lerp(slider.transform.localScale, showerUIScale, Time.deltaTime * 10);
            sliderLight.gameObject.transform.localScale = Vector3.Lerp(sliderLight.gameObject.transform.localScale, showerUIScale, Time.deltaTime * 10);
            //slider.gameObject.transform.localScale = showerUIScale;
            //sliderLight.gameObject.transform.localScale = showerUIScale;
        }
        else
        {
            showerUILight.gameObject.SetActive(false);
            slider.transform.localScale = Vector3.Lerp(slider.transform.localScale, defaultShowerUIScale, Time.deltaTime * 10);
            sliderLight.gameObject.transform.localScale = Vector3.Lerp(sliderLight.gameObject.transform.localScale, defaultShowerUIScale, Time.deltaTime * 10);

        }
        ShowerPointVal = Mathf.Lerp(slider.value, showerPoint, Time.deltaTime);
        slider.value = ShowerPointVal;
        sliderLight.value = showerPoint;
        //t += Time.deltaTime; 
        //showerPoint = 1; //デバッグ用
        //スキルの判定
        if (ShowerPointVal > 0)
        {
            showerOn = true;

            if (on && OVRInput.Get(actionBtn) || (on && Input.GetKey(KeyCode.Space)))
            {
                ShowerObj.Play();
                showerPoint -= Time.deltaTime * showerSpeed;
                ShowerPointVal -= Time.deltaTime * showerSpeed;
                StartCoroutine("ShowerTime");
            }
        }
        else
        {
            if (showerOn)
            {
                ShowerStop();
                AudioManager.manager.PlayPoint(AudioManager.manager.data.NoGageShower, gameObject, 0.4f);
            showerOn = false;

            }
        }
        if (ShowerPointVal < 0 && (OVRInput.GetDown(actionBtn) || Input.GetKeyDown(KeyCode.Space)))
        {
            AudioManager.manager.PlayPoint(AudioManager.manager.data.NoGageShower, gameObject,0.4f);
        }
        if (OVRInput.GetUp(actionBtn) || Input.GetKeyUp(KeyCode.Space))
        {
            ShowerStop();
        }
        //cool = 0;
        image.sprite = InholeSp;
        //s\吸い込み判定
        if (OVRInput.GetDown(showerBtn) || Input.GetMouseButtonDown(0))
        {
            OnHale = true;
            Inhale();
        }
        if (OVRInput.GetUp(showerBtn) || Input.GetMouseButtonUp(0))
            UpInhale();
    }
    IEnumerator ShowerTime()
    {
        on = false;
        yield return new WaitForSeconds(0.2f);
        AudioManager.manager.PlayPoint(AudioManager.manager.data.shower, ShowerObj.gameObject);
        on = true;
    }
    private void ShowerStop()
    {
        ShowerObj.Stop();
        StopCoroutine("ShowerTime");
        AudioManager.manager.StopPoint(ShowerObj.gameObject);
        on = true;
    }
    private void Inhale()
    {
        if (InHoleObj.gameObject.GetComponent<AudioSource>())
        {
            if (!InHoleObj.gameObject.GetComponent<AudioSource>().isPlaying)
                AudioManager.manager.PlayPoint(AudioManager.manager.data.suction, InHoleObj.gameObject);
        }
        else
            AudioManager.manager.PlayPoint(AudioManager.manager.data.suction, InHoleObj.gameObject);
        InHoleObj.GetComponent<ParticleSystem>().Play();
        //StartCoroutine("UpInhale");
    }
    private void UpInhale()
    {
        //yield return new WaitForSeconds(inHoleTime);
        OnHale = false;
        InHoleObj.GetComponent<ParticleSystem>().Stop();

        InHoleObj.GetComponent<AudioSource>().Stop();
        //image.sprite = NoholeSp;
        //cool = coolTime;
    }

    private void OnCollisionStay(Collision other)
    {
        Paint(other);


        if (other.transform.tag == "Wall")
        {
            showerPoint += Time.deltaTime*showerHeelPower;
            time += Time.deltaTime;
            pontime += Time.deltaTime;
            if (time > 0.8f)
            {
                time = 0;
                Instantiate(ShineEffect, transform.position, transform.rotation);
            }
            if (pontime > 0.15f)
            {
                pontime = 0;
                AudioManager.manager.PlayPoint(AudioManager.manager.data.lowpon, gameObject, 0.5f);
            }
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
        if (other.tag == "Wall")
            showerPoint += Time.deltaTime * showerHeelPower;
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
    public void LineSet(float point)
    {
        GameObject obj = Instantiate(lightLine, lineEndTra.position, Quaternion.identity, transform);
        obj.GetComponent<showerLine>().SetPotision(point, lineStartTra, this);
    }
    public Vector3 GetHit() => hitpoint;
    public void SetHit(Vector3 x) => hitpoint = x;
    public float GetInhaleDis() => inHaleDis;
    public bool GetInHale() => OnHale;
    public float GetInHaleSpeed() => inHaleSpeed;
    public void AddShowerPoint(float x)
    {
        showerPoint += x;
    }
    //public float GetCool() => cool / coolTime;
}
