﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIGBallSC : MonoBehaviour
{
    [SerializeField] Material mat;
    [SerializeField] float matSpeed = 1;
    [SerializeField] float scaleSpeed = 1;
    [SerializeField] float max = 10;
    [SerializeField] float border;
    [SerializeField] float overmatSpeed;
    [SerializeField] GameObject BIGBETA;
    GameObject MainBGM;
    private Transform pa;
    float time = 0;
    bool borderOver=true;
    BouSakiScript bousaki;

    bool bigArrivalFalg = true;
    void Start()
    {
        MainBGM = GameObject.Find("BGMAudio");
        mat.SetFloat("_hagesisa", 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime*matSpeed;
        if (time >= border&&borderOver)
        {
            borderOver = false;
            matSpeed = overmatSpeed;
            GameObject obj = Instantiate(BIGBETA, pa.position, Quaternion.identity);
            AudioManager.manager.PlayPoint(AudioManager.manager.data.bossBGM, this.gameObject);
            Destroy(MainBGM);
            obj.transform.parent = pa;
            obj.transform.position = new Vector3(0,0,0);
            obj.transform.localEulerAngles = new Vector3(0,0,0);
        }
        if (time <= max)
        {
            if(bigArrivalFalg)
            {
                AudioManager.manager.PlayPoint(AudioManager.manager.data.bigArrival, this.gameObject);
                bigArrivalFalg = false;
            }
            mat.SetFloat("_hagesisa", time);
            transform.localScale += Vector3.one * 0.01f*scaleSpeed;
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }
    public void setParent(Transform tra) => pa = tra;
    public void setSaki(BouSakiScript saki) => bousaki = saki;
}
