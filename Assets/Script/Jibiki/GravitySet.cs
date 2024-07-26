using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ベタの動き、重力を管理 */

public class GravitySet : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float rotatedis = 1.0f;

    Rigidbody rb;
    float distance;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // どんな向きでもベタに対して下向きに重力をかける
        rb.AddForce(-transform.up * 9.8f, ForceMode.Acceleration);

        this.transform.position += transform.forward * speed * Time.deltaTime;

        RaycastHit hit;
        // オブジェクトの前方にレイキャストを飛ばす
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            // ヒットした位置までの距離を取得
            distance = hit.distance;
            //Debug.Log("Distance to wall: " + distance);
        }

        // 壁との距離が近くなったら90度回転させる
        if(distance < rotatedis)
        {
            transform.Rotate(Vector3.right, -90f);
        }
    }
}
