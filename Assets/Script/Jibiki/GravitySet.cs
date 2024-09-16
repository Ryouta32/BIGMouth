using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;

/* �x�^�̓����A�d�͂��Ǘ� */

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
        // �ǂ�Ȍ����ł��x�^�ɑ΂��ĉ������ɏd�͂�������
        if (rb.velocity.magnitude > 20)
            rb.AddForce(-transform.up * 9.8f, ForceMode.Acceleration);

        this.transform.position += transform.forward * speed * Time.deltaTime;
        distance = 100;
        RaycastHit hit;

         Vector3 raypos = (transform.forward*2) + (-transform.up*2);
        Debug.Log(raypos);
        Vector3 rayStartPos = transform.position;
        rayStartPos.z += (transform.localScale.z/1.2f);


        //�I�u�W�F�N�g�̉���Ray���΂�
        if (Physics.Raycast(rayStartPos, raypos, out hit, 1f, mask))
        {
            // �q�b�g�����ʒu�܂ł̋������擾
            distance = hit.distance;
            Debug.DrawRay(rayStartPos, raypos * hit.distance, Color.blue);
            if (distance < rotatedis)
            {
                Vector3.Lerp(transform.position, hit.point, 1f);
                Quaternion rot = Quaternion.FromToRotation(transform.up, hit.normal);
                rb.MoveRotation(rot * transform.rotation);
                //transform.position += transform.localScale.y / 1.98f * hit.normal;
                Debug.Log("�������Ă��[");
                //transform.Rotate(Vector3.right, -90f);
            }
        }else
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        //if (Physics.Raycast(player.transform.position, player.transform.transform.forward, out hit, Mathf.Infinity))
        //{
        //    Debug.DrawRay(player.transform.position, player.transform.transform.forward * hit.distance, Color.yellow);

        //    item1.transform.position = hit.point; // Cube�����C�̓��������Ƃ���Ɉړ�
        //    item1.transform.rotation = Quaternion.FromToRotation(item.transform.up, hit.normal); // Cube�̏���������C�����������Ƃ���̕\�ʂ̕����ɂ���
        //    item1.transform.position += item1.transform.localScale.y / 1.98f * hit.normal; // Cube�����܂�Ȃ��悤�ɁA�\�ʕ����ɏ���������
        //}

    }
}
