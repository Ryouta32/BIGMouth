﻿using Es.InkPainter;
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
    bool on=true;
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
            ShowerObj.SetActive(true);
            StartCoroutine("ShowerTime");
        }
        if (OVRInput.GetUp(actionBtn) || Input.GetKeyUp(KeyCode.Space))
        {
            ShowerObj.SetActive(false);
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
    }
    private void UpInhale()
    {

    }

    private void OnCollisionStay(Collision other)
    {

        PaintManager pManager = new PaintManager();
        if (other.gameObject.CompareTag(objTag))
            pManager.Paint(other, useMethodType, !erase, brush, transform, true, objTag);
        else
            pManager.Paint(other, useMethodType, erase, brush, transform, true, objTag);

        this.time += Time.deltaTime;
        if (this.time > 0.8f)
        {
            this.time = 0;
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
    public Vector3 GetHit() => hitpoint;
    public void SetHit(Vector3 x) => hitpoint = x;
    public float GetInhaleDis() => inHaleDis;
    public bool GetInHale() => OnHale;
    public float GetInHaleSpeed() => inHaleSpeed;
}
