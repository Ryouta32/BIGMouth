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
            GameObject obj = Instantiate(BIGBETA, transform.position, Quaternion.identity);
            obj.transform.parent = pa;
        }
        if (time <= max)
        {
            mat.SetFloat("_hagesisa", time);
            transform.localScale += Vector3.one * 0.01f*scaleSpeed;
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }
    public void setParent(Transform tra) => pa = tra;
}
