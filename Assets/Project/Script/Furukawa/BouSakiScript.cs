using Es.InkPainter;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BouSakiScript : MonoBehaviour
{

    [SerializeField] bouScript bouSC;

    [SerializeField]
    private Brush brush;

    [SerializeField]
    private PaintManager.UseMethodType useMethodType = PaintManager.UseMethodType.RaycastHitInfo;

    [SerializeField]
    bool erase = false;

    [SerializeField]
    TextMeshProUGUI text;
    float time;

    [SerializeField] private OVRInput.RawButton actionBtn;

    [SerializeField] GameObject ShowerObj;
    [SerializeField] GameObject showerCube;
    private GameObject currentBall;
    [SerializeField] float power;
    [Header("吸い込みの距離")]
    [SerializeField] float inHaleDis=0.5f;
    [Header("吸い込み速度")]
    [SerializeField] float inHaleSpeed=1;
    [SerializeField] string objTag="MIMIC";
    [SerializeField] GameObject ShineEffect;
    [SerializeField] AudioManager audioM;
    bool on=true;
    float paintTime;
    Quaternion defaultQuaternion;
   Vector3 hitpoint;
   public bool OnHale;
    void Start()
    {
        defaultQuaternion = this.transform.rotation;
        hitpoint = Vector3.zero;

    }

    void Update()
    {
        if (on&&OVRInput.Get(actionBtn)|| (on && Input.GetKey(KeyCode.Space)))
        {
            //ShowerObj.SetActive(true);
            StartCoroutine("ShowerTime");
        }
        if (OVRInput.GetUp(actionBtn) || Input.GetKeyUp(KeyCode.Space))
        {
            //ShowerObj.SetActive(false);
            StopCoroutine("ShowerTime");
            on = true;
        }
        if (OVRInput.Get(OVRInput.RawButton.B) || Input.GetMouseButton(0))
        {
            Inhale();
        }
        if(OVRInput.GetUp(OVRInput.RawButton.B) | Input.GetMouseButtonUp(0))
        {
            UpInhale();
        }

    }
    IEnumerator ShowerTime()
    {
        on = false;
        yield return new WaitForSeconds(0.2f);

        GameObject obj;
        obj = Instantiate(showerCube, transform.position, Quaternion.identity);
        obj.GetComponent<Rigidbody>().AddForce(bouSC.pos.normalized*power);
        obj.GetComponent<ShowerCube>().setTag(objTag);
        on = true;
    }
    private void Inhale()
    {
        OnHale = true;
        audioM.PlayPoint(audioM.data.inhale, this.gameObject);
    }
    private void UpInhale()
    {

    }

    private void OnCollisionStay(Collision other)
    {
        paintTime += Time.deltaTime;
        PaintManager pManager = new PaintManager();
        if (other.gameObject.CompareTag(objTag))
            pManager.Paint(other, useMethodType, !erase, brush, transform, true, objTag);
        else
            pManager.Paint(other, useMethodType, erase, brush, transform, true, objTag);

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
        if(collision.gameObject.CompareTag(objTag))
        pManager.Paint(collision, useMethodType, !erase, brush, transform, true,objTag);
        else
            pManager.Paint(collision, useMethodType, erase, brush, transform, true, objTag);


        hitpoint = collision.contacts[0].point;
        bouSC.HitPos();
    }
    private void OnTriggerStay(Collider other)
    {
        paintTime += Time.deltaTime;
        PaintManager pManager = new PaintManager();
        if (other.gameObject.CompareTag(objTag))
            pManager.Paint(other, useMethodType, !erase, brush, transform, true, objTag);
        else
            pManager.Paint(other, useMethodType, erase, brush, transform, true, objTag);

        time += Time.deltaTime;
        if (time > 0.8f)
        {
            time = 0;
            Instantiate(ShineEffect, transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PaintManager pManager = new PaintManager();
        if (other.gameObject.CompareTag(objTag))
            pManager.Paint(other, useMethodType, !erase, brush, transform, true, objTag);
        else
            pManager.Paint(other, useMethodType, erase, brush, transform, true, objTag);


        hitpoint = other.ClosestPointOnBounds(this.transform.position);
        bouSC.HitPos();
    }
    private void OnTriggerExit(Collider other)
    {
        hitpoint = Vector3.zero;
        bouSC.ExisPos();
    }
    public Vector3 GetHit() => hitpoint;
    public void SetHit(Vector3 x) => hitpoint = x;
    public float GetInhaleDis() => inHaleDis;
    public bool GetInHale() => OnHale;
    public float GetInHaleSpeed() => inHaleSpeed;
}
