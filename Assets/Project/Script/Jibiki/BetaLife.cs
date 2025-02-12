﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaLife : MonoBehaviour
{
    EnemyScript enemySC;
    float time;

    private void Start()
    {
        enemySC = GetComponent<EnemyScript>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.CompareTag("Brush"))
        //{
        //    enemySC.HitDamage();
        //}
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brush"))
        {
            time += Time.deltaTime;
            if (time > 0.2f)
            {
                time = 0;
                enemySC.HitDamage();   

            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Brush"))
        time = 0 ;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Brush"))
        {
            time += Time.deltaTime;
            if (time > 0.2f)
            {
                time = 0;
                enemySC.HitDamage();

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brush"))
        {
            time += Time.deltaTime;
            if (time > 0.2f)
            {
                time = 0;
                enemySC.HitDamage();

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Brush"))
            time = 0;
    }
}
