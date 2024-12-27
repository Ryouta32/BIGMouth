﻿using Oculus.Interaction.Body.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;


/* ベタの動き重力を管理 */

public class GravitySet : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float rotatedis;

    Rigidbody rb;
    float distance;
    LayerMask mask;

    public Vector3 gravityVec = Vector3.up;
    Vector3 temp;
    public bool move;
    private bool rotate;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        //GetComponent<Rigidbody>().useGravity = true;
        mask = LayerMask.GetMask("Wall");
        rotate = true;

    }
    public void OnMove()
    {
        move = true;
    }
    public void OffMove()
    {
        move = false;
    }
    void Update()
    {
        // どんな向きでもベタに対して下向きに重力をかける
        //rb.AddForce(-transform.up * 9.8f*Time.deltaTime, ForceMode.Acceleration);

        if (move)
            this.transform.position += transform.forward * speed * Time.deltaTime;
        distance = 100;
        RaycastHit hit;

        Vector3 raypos = (transform.forward * 4) + (-transform.up * 2);
        Vector3 rayStartPos = this.transform.position;
        //rayStartPos += transform.forward * 0.01f;

        //オブジェクトの前にrayを飛ばす
        if (rotate)
            if (Physics.Raycast(rayStartPos, transform.forward, out hit, 1f, mask))
            {
                // ヒットした位置までの距離を取得
                distance = hit.distance;
                Debug.DrawRay(rayStartPos, transform.forward * hit.distance, Color.blue);
                if (distance < rotatedis)
                {

                    //transform.position = hit.point;
                    //Vector3.Lerp(transform.position, hit.point, 1f);
                    gravityVec = (transform.position - hit.point);
                    Debug.Log(gravityVec);
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation, 0.1f);
                    StartCoroutine("TriggerOnRotate");
                    //Quaternion rot = Quaternion.FromToRotation(transform.up, hit.normal);
                    //rb.MoveRotation(rot * transform.rotation);
                    //transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal);
                }
            }
            else if (Physics.Raycast(rayStartPos, -transform.up, out hit, 1f, mask))
            {
                distance = hit.distance;
                Debug.DrawRay(rayStartPos, -transform.up * hit.distance, Color.blue);

                if (distance < rotatedis)
                {
                    gravityVec = (transform.position - hit.point);

                    if (gravityVec.x < 0.001f)
                        gravityVec.x = 0;
                    if (gravityVec.y < 0.001f)
                        gravityVec.y = 0;
                    if (gravityVec.z < 0.001f)
                        gravityVec.z = 0;
                    
                    //Vector3.Lerp(transform.position, hit.point, 1f);
                    //Quaternion rot = Quaternion.FromToRotation(transform.up, hit.normal);
                    //transform.rotation = Quaternion.FromToRotation(transform.up, gravityVec) * transform.rotation;
                    //rb.MoveRotation(rot * transform.rotation);
                }

            }
            else
            {
                gravityVec = Vector3.up;

                //transform.transform.rotation = new Quaternion() ;
            }
        //if (Physics.Raycast(player.transform.position, player.transform.transform.forward, out hit, Mathf.Infinity))
        //{
        //    Debug.DrawRay(player.transform.position, player.transform.transform.forward * hit.distance, Color.yellow);

        //    item1.transform.position = hit.point; // Cubeをレイの当たったところに移動
        //    item1.transform.rotation = Quaternion.FromToRotation(item.transform.up, hit.normal); // Cubeの上方向をレイが当たったところの表面の方向にする
        //    item1.transform.position += item1.transform.localScale.y / 1.98f * hit.normal; // Cubeが埋まらないように、表面方向に少し動かす
        //}

    }

    IEnumerator TriggerOnRotate()
    {
        rotate = false;
        yield return new WaitForSeconds(0.1f);
        rotate = true;

    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(gravityVec.normalized * -98f);

        transform.rotation = Quaternion.FromToRotation(transform.up, gravityVec) * transform.rotation;
    }
}
