using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* �x�^�̓����A�d�͂��Ǘ� */

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
        // �ǂ�Ȍ����ł��x�^�ɑ΂��ĉ������ɏd�͂�������
        if(rb.velocity.magnitude>20)
        rb.AddForce(-transform.up * 9.8f, ForceMode.Acceleration);

        this.transform.position += transform.forward * speed * Time.deltaTime;
        distance = 100;
        RaycastHit hit;
        // �I�u�W�F�N�g�̑O���Ƀ��C�L���X�g���΂�
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
        {
            // �q�b�g�����ʒu�܂ł̋������擾
            distance = hit.distance;
            //Debug.Log("Distance to wall: " + distance);
        }
        if(!Physics.Raycast(transform.position,-Vector3.up,out hit, 10f))
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }else // �ǂƂ̋������߂��Ȃ�����90�x��]������
        if(distance < rotatedis)
        {
            transform.Rotate(Vector3.right, -90f);
        }
    }
}
