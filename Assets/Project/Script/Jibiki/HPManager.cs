using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    Image UI_HP;
    CanvasChange cc;
    Animation Fadeanim;
    bool childFlag;
    bool count;

    public static float hp;
    public static float hpPiece;

    // Start is called before the first frame update
    void Start()
    {
        count = true;
        childFlag = true;
        UI_HP = GameObject.Find("HP").GetComponent<Image>();
        cc = GameObject.Find("CanvasChange").GetComponent<CanvasChange>();
        Fadeanim = GameObject.Find("RedFade").GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        UI_HP.fillAmount = hpPiece / hp;

        //警告音鳴らす
        if (UI_HP.fillAmount < 0.3 && count)
        {
            count = false;
            StartCoroutine("UIcount");
        }

        if (UI_HP.fillAmount <= 0 && childFlag)
        {
            childFlag = false;
            cc.Phase[0] = false;
            cc.Phase[2] = true;
            AudioManager.manager.PlayPoint(AudioManager.manager.data.stageEnergency, this.gameObject, 5);
        }
        else if (UI_HP.fillAmount <= 0)
        {
            Fadeanim.Play("RedFade");
        }
    }

    IEnumerator UIcount()
    {
        AudioManager.manager.PlayPoint(AudioManager.manager.data.stageEnergency, this.gameObject);
        Fadeanim.Play("RedFade");
        yield return new WaitForSeconds(5.0f);
        count = true;
    }
}
