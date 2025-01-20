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
    [SerializeField] float power;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dragon"))
        {
            if (!other.gameObject.GetComponent<Rigidbody>())
            {
                mr = other.gameObject.GetComponent<MeshRenderer>();
                mr.material = PieceMaterial;

                rb = other.gameObject.AddComponent<Rigidbody>();
                rb.AddForce(other.gameObject.transform.up * power, ForceMode.Impulse);

                HPManager.hpPiece -= 1;
                Destroy(other.gameObject, 5.0f);
            }
        }
    }
}
