using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*壁に当たった時に*/

public class WallEntrance : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer mr;
    [SerializeField] Material PieceMaterial;

    [Tooltip("崩れるときのちから")]
    [SerializeField] Vector3 power;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (!other.gameObject.GetComponent<Rigidbody>())
            {
                mr = other.gameObject.GetComponent<MeshRenderer>();
                mr.material = PieceMaterial;

                rb = other.gameObject.AddComponent<Rigidbody>();

                rb.AddForce(power);

                Destroy(other.gameObject, 5.0f);
            }
        }
    }
}
