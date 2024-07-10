using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySet : MonoBehaviour
{
    public float speed = 10f;

    Rigidbody rb;

    Transform _transform;

    bool gravityflag1 = false;
    bool gravityflag2 = false;
    bool gravityflag3 = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position -= transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0, -1f, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, 1f, 0);
        }

        if(gravityflag1)
        {
            rb.AddForce(Vector3.right * -9.8f, ForceMode.Acceleration);
        }
        if(gravityflag2)
        {
            rb.AddForce(Vector3.forward * 9.8f, ForceMode.Acceleration);
        }
        if(gravityflag3)
        {
            rb.AddForce(Vector3.right * 9.8f, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall1"))
        {
            gravityflag1 = true;
            rb.useGravity = false;
            _transform.rotation = Quaternion.AngleAxis(-90f, Vector3.right);
        }
        if(collision.gameObject.CompareTag("Wall2"))
        {
            gravityflag2 = true;
            rb.useGravity = false;
            _transform.rotation = Quaternion.AngleAxis(-90f, Vector3.right);
        }
        if(collision.gameObject.CompareTag("Wall3"))
        {
            gravityflag3 = true;
            rb.useGravity = false;
            _transform.rotation = Quaternion.AngleAxis(-90f, Vector3.right);
        }
        if(collision.gameObject.CompareTag("Floor"))
        {
            if(gravityflag1)
            {
                _transform.rotation = Quaternion.AngleAxis(-90f, Vector3.up);
                gravityflag1 = false;
            }
            if(gravityflag2)
            {
                _transform.rotation = Quaternion.AngleAxis(0f, Vector3.right);
                gravityflag2 = false;
            }
            if(gravityflag3)
            {
                _transform.rotation = Quaternion.AngleAxis(90f, Vector3.up);
                gravityflag3 = false;
            }
            rb.useGravity = true;
        }
    }
}
