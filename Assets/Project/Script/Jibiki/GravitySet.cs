using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;
using UnityEngine.UI;

/* ベタの動き、重力を管理 */

public class GravitySet : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float rotatedis = 1.0f;

    Rigidbody rb;
    float distance;
    LayerMask mask;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mask = LayerMask.GetMask("Wall");
    }

    void Update()
    {
        // どんな向きでもベタに対して下向きに重力をかける
            rb.AddForce(-transform.up * 9.8f*Time.deltaTime, ForceMode.Acceleration);

        this.transform.position += transform.forward * speed * Time.deltaTime;
        distance = 100;
        RaycastHit hit;

         Vector3 raypos = (transform.forward*2) + (-transform.up*2);
        Vector3 rayStartPos = transform.position;
        rayStartPos.z += (transform.localScale.z/2f);


        //オブジェクトの下にRayを飛ばす
        if (Physics.Raycast(rayStartPos, raypos, out hit, 1f, mask))
        {
            // ヒットした位置までの距離を取得
            distance = hit.distance;
            Debug.DrawRay(rayStartPos, raypos * hit.distance, Color.blue);
            if (distance < rotatedis)
            {
                Vector3.Lerp(transform.position, hit.point, 1f);
                Quaternion rot = Quaternion.FromToRotation(transform.up, hit.normal);
                rb.MoveRotation(rot * transform.rotation);
                //transform.position += transform.localScale.y / 1.98f * hit.normal;
                Debug.Log( "前");
                //transform.Rotate(Vector3.right, -90f);
            }
        }
        else if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1f, mask))
        {
            distance = hit.distance;
            if (distance < rotatedis)
            {
                Vector3.Lerp(transform.position, hit.point, 1f);
                Quaternion rot = Quaternion.FromToRotation(transform.up, hit.normal);
                rb.MoveRotation(rot * transform.rotation);
                Debug.Log("↓");
            }

        }
        else
        {
            Debug.Log("何も当たっていない");
            transform.transform.rotation = new Quaternion() ;
        }
        //if (Physics.Raycast(player.transform.position, player.transform.transform.forward, out hit, Mathf.Infinity))
        //{
        //    Debug.DrawRay(player.transform.position, player.transform.transform.forward * hit.distance, Color.yellow);

        //    item1.transform.position = hit.point; // Cubeをレイの当たったところに移動
        //    item1.transform.rotation = Quaternion.FromToRotation(item.transform.up, hit.normal); // Cubeの上方向をレイが当たったところの表面の方向にする
        //    item1.transform.position += item1.transform.localScale.y / 1.98f * hit.normal; // Cubeが埋まらないように、表面方向に少し動かす
        //}

    }
}
