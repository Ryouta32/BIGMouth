﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPManager : MonoBehaviour
{
    Image UI_HP;
    CanvasChange cc;
    public Animation Fadeanim;
    public Animator HPanim;
    bool childFlag;
    bool count;

    public static float hp;
    public static float hpPiece;

    TextMeshProUGUI textText;

    public static float time;
    float maxtime = 180.0f;

    int UICount = 0;

    float ima;

    // Start is called before the first frame update
    void Start()
    {
        count = true;
        childFlag = true;
        UI_HP = GameObject.Find("HP").GetComponent<Image>();
        cc = GameObject.Find("CanvasChange").GetComponent<CanvasChange>();
        Fadeanim = GameObject.Find("RedFade").GetComponent<Animation>();
        HPanim = GameObject.Find("HP").GetComponent<Animator>();
        textText = GameObject.Find("UIText").GetComponent<TextMeshProUGUI>();
        UI_HP.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float mae = UI_HP.fillAmount;

        time += Time.deltaTime;
        //UI_HP.fillAmount = 1 - (time / maxtime);
        ima = hpPiece / hp;
        //UI_HP.fillAmount = hpPiece / hp;
        if(time < 0)
        {
            time = 0;
        }

        float ato = UI_HP.fillAmount;
        UI_HP.fillAmount = hpPiece / hp;


        //UI_HP.fillAmount = hpPiece / hp;
        //Debug.Log("hp：" + hp);
        //Debug.Log("hpPiece：" + hpPiece);
        //textText.text = UI_HP.fillAmount.ToString();

        //警告音鳴らす
        if(UI_HP.fillAmount >= 0.5f)
        {
            HPanim.SetBool("Play", false);
            UI_HP.GetComponent<Image>().color = Color.white;
        }

        if (UI_HP.fillAmount < 0.5f && count)
        {
            count = false;
            StartCoroutine("UIcount");
        }

        if (UI_HP.fillAmount < 0.1f && childFlag)
        {
            childFlag = false;
            cc.Phase[0] = false;
            cc.Phase[2] = true;
            cc.CanvasActive();
            AudioManager.manager.PlayPoint(AudioManager.manager.data.stageEnergency, this.gameObject, 5);
        }
        else if (UI_HP.fillAmount < 0.1f)
        {
            Fadeanim.Play("RedFade");
        }
    }

    IEnumerator UIcount()
    {
        AudioManager.manager.PlayPoint(AudioManager.manager.data.stageEnergency, this.gameObject);
        Fadeanim.Play("RedFade");
        HPanim.SetBool("Play", true);
        yield return new WaitForSeconds(2.0f);
        if(UICount == 2)
        {
            UICount = 0;
        }
        if(UICount == 0)
        {
            AudioManager.manager.PlayPoint(AudioManager.manager.data.baburudenaosu, this.gameObject, 2.0f);
        }
        yield return new WaitForSeconds(3.3f);
        count = true;
        UICount++;
    }
}
