using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* �x�^�̓����A�d�͂��Ǘ� */

public class GravitySet : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    Rigidbody rb;

    Transform _transform;

    bool gravityflag1 = false;
    bool gravityflag2 = false;
    bool gravityflag3 = false;
    bool gravityflag4 = false;

    float distance;
    [SerializeField] float rotatedis = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // �ǂ�Ȍ����ł��x�^�ɑ΂��ĉ������ɏd�͂�������
        rb.AddForce(-transform.up * 9.8f, ForceMode.Acceleration);

        this.transform.position += transform.forward * speed * Time.deltaTime;

        //if (Input.GetKey(KeyCode.UpArrow))
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += transform.forward * speed * Time.deltaTime;
        }
        //if (Input.GetKey(KeyCode.LeftArrow))
        if (OVRInput.GetDown(OVRInput.RawButton.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0, -1f, 0);
        }
        //if (Input.GetKey(KeyCode.RightArrow))
        if (OVRInput.GetDown(OVRInput.RawButton.B) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, 1f, 0);
        }

        RaycastHit hit;
        // �I�u�W�F�N�g�̑O���Ƀ��C�L���X�g���΂�
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            // �q�b�g�����ʒu�܂ł̋������擾
            distance = hit.distance;
            //Debug.Log("Distance to wall: " + distance);
        }

        // �ǂƂ̋������߂��Ȃ�����90�x��]������
        if(distance < rotatedis)
        {
            transform.Rotate(Vector3.right, -90f);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Wall1"))
    //    {
    //        if(gravityflag1 == false)
    //        {
    //            transform.Rotate(Vector3.right, -90f);
    //            gravityflag1 = true;
    //        }
    //    }
    //    if(collision.gameObject.CompareTag("Wall2"))
    //    {
    //        if(gravityflag2 == false)
    //        {
    //            transform.Rotate(Vector3.right, -90f);
    //            gravityflag2 = true;
    //        }
    //    }
    //    if (collision.gameObject.CompareTag("Wall3"))
    //    {
    //        if (gravityflag3 == false)
    //        {
    //            transform.Rotate(Vector3.right, -90f);
    //            gravityflag3 = true;
    //        }
    //    }
    //    if (collision.gameObject.CompareTag("Wall4"))
    //    {
    //        if (gravityflag4 == false)
    //        {
    //            transform.Rotate(Vector3.right, -90f);
    //            gravityflag4 = true;
    //        }
    //    }

    //    if (collision.gameObject.CompareTag("Floor"))
    //    {
    //        if(gravityflag1)
    //        {
    //            transform.Rotate(Vector3.right, -90f);
    //            gravityflag1 = false;
    //        }
    //        if(gravityflag2)
    //        {
    //            transform.Rotate(Vector3.right, -90f);
    //            gravityflag2 = false;
    //        }
    //        if(gravityflag3)
    //        {
    //            transform.Rotate(Vector3.right, -90f);
    //            gravityflag3 = false;
    //        }
    //        if(gravityflag4)
    //        {
    //            transform.Rotate(Vector3.right, -90f);
    //            gravityflag4 = false;
    //        }
    //    }
    //}
}
