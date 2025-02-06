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

    PieceManager pieceManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dragon"))
        {
            if (other.transform.parent.parent.GetComponent<PieceManager>())
            {
                pieceManager = other.transform.parent.parent.GetComponent<PieceManager>();
            }
            if (!other.gameObject.GetComponent<Rigidbody>())
            {
                mr = other.gameObject.GetComponent<MeshRenderer>();
                mr.material = PieceMaterial;

                rb = other.gameObject.AddComponent<Rigidbody>();
                rb.AddForce(other.gameObject.transform.up * power, ForceMode.Impulse);
                if (pieceManager != null)
                    pieceManager.RemoveItem(other.transform);
                HPManager.hp -= 1;
                Destroy(other.gameObject, 5.0f);
            }
        }
    }
}
