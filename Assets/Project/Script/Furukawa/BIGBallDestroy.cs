using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIGBallDestroy : MonoBehaviour
{
    [SerializeField] Material mat;
    BigEnemyScript big;
    float _hagesisa = 7;
    float _hagesii;
    void Start()
    {
        mat.SetFloat("_hagesisa", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_hagesisa == _hagesii)
            Mathf.Lerp(_hagesii, _hagesisa, Time.deltaTime*2);

            mat.SetFloat("_hagesisa", _hagesii);

        if(_hagesii>6f&&_hagesii<5)
            big.Clear();
    }

    public void SetHagesisa(float hagesisa)=>_hagesisa=hagesisa;
    public void SetBIG(BigEnemyScript bigEnemy)=>big=bigEnemy;
}
