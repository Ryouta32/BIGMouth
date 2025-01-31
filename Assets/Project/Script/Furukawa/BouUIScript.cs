using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouUIScript : MonoBehaviour
{
    [SerializeField]BouSakiScript saki;
    [SerializeField] Image[] suikomis;
    [SerializeField] Image gage;
    [SerializeField] Animator Pikan;
    [SerializeField] Image trigger;
    [SerializeField] Sprite[] triggerSprites;
    [SerializeField] float triggerTime;
    bool on;
    // Start is called before the first frame update
    void Start()
    {
        saki.GetComponent<BouSakiScript>();
        on = true;
        StartCoroutine("Trigger");
    }

    // Update is called once per frame
    void Update()
    {
        gage.fillAmount = Mathf.Clamp01(1 - saki.GetCool());
        if (saki.GetCool() > 0)
        {
            for (int i = 0; i < suikomis.Length; i++)
                suikomis[i].color = new Color(suikomis[i].color.r, suikomis[i].color.g, suikomis[i].color.b, 0.3f);
            on = false;
        }
        else if(!on)
        {
            for (int i = 0; i < suikomis.Length; i++)
                suikomis[(i + 1) % suikomis.Length].color = Color.white;
            Pikan.SetTrigger("Pikan");
            on = true;
        }
    }
    IEnumerator Trigger()
    {
        int count = 0 ;
        while (true)
        {
            yield return new WaitForSeconds(triggerTime);
            trigger.sprite = triggerSprites[count];
            count++;
            if(count ==triggerSprites.Length)
                count = 0 ;
        }
    }
}
