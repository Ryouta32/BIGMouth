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
    bool on;
    // Start is called before the first frame update
    void Start()
    {
        saki.GetComponent<BouSakiScript>();
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        gage.fillAmount = Mathf.Clamp01(1 - saki.GetCool());
        if (saki.GetCool() > 0)
        {
            for (int i = 0; i < suikomis.Length; i++)
                suikomis[i].color = new Color(suikomis[i].color.r, suikomis[i].color.g, suikomis[i].color.b, 0.5f);
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
}
