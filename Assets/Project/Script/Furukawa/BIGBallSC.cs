using System.Collections;
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
    private Transform pa;
    float time = 0;
    bool borderOver=true;
    BouSakiScript bousaki;
    private Transform linepos;

    bool bigArrivalFalg = true;
    public static bool BIGFlag = false;
    void Start()
    {
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
            AudioManager.manager.PlayPoint(AudioManager.manager.data.bigbetaato, this.gameObject, 2);

            obj.GetComponent<BigEnemyScript>().linePos = linepos;
            BIGFlag = true;
            obj.transform.parent = pa;
            obj.transform.position = new Vector3(0,0,0);
            obj.transform.localEulerAngles = new Vector3(0,0,0);
        }
        if (time <= max)
        {
            if(bigArrivalFalg)
            {
                AudioManager.manager.PlayPoint(AudioManager.manager.data.bigbetadeta, this.gameObject,2);

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
    public void setLinePos(Transform s) => linepos = s;
}
