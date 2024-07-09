using Es.InkPainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkEnemyScript : MonoBehaviour
{
    [System.Serializable]
    private enum UseMethodType
    {
        RaycastHitInfo,
        WorldPoint,
        NearestSurfacePoint,
        DirectUV,
    }

    [SerializeField]
    private Brush brush;

    [SerializeField]
    private UseMethodType useMethodType = UseMethodType.RaycastHitInfo;

    [SerializeField]
    bool erase = false;

    Rigidbody rb;
    private bool col=false;
    Vector3 power=new Vector3(-2,0,0);
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude <= 5f&&col)
        {
            rb.AddForce(power);

        }
        StartCoroutine("comp");
    }
    IEnumerator comp()
    {
        yield return new WaitForSeconds(2f);
        power = power * -1;
        rb.velocity =Vector3.zero ;

    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 hitPos;
        RaycastHit hit;
        bool success = true;
        col = true;
        foreach (ContactPoint point in collision.contacts)
        {
            hitPos = point.normal;
            Ray ray = new Ray( transform.position,-hitPos);

            Debug.DrawRay(transform.position,- hitPos, Color.blue,0.1f );

            if (Physics.Raycast(ray, out hit,(transform.localScale.x/2)+0.1f))
            {
                InkCanvas paint = hit.transform.GetComponent<InkCanvas>();

                if (paint != null)
                {
                    switch (useMethodType)
                    {
                        case UseMethodType.RaycastHitInfo:
                            success = erase ? paint.Erase(brush, hit) : paint.Paint(brush, hit);

                            break;
                        case UseMethodType.WorldPoint:
                            success = erase ? paint.Erase(brush, hit.point) : paint.Paint(brush, hit.point);
                            break;

                        case UseMethodType.NearestSurfacePoint:
                            success = erase ? paint.EraseNearestTriangleSurface(brush, hit.point) : paint.PaintNearestTriangleSurface(brush, hit.point);
                            break;

                        case UseMethodType.DirectUV:
                            if (!(hit.collider is MeshCollider))
                                Debug.LogWarning("Raycast may be unexpected if you do not use MeshCollider.");
                            success = erase ? paint.EraseUVDirect(brush, hit.textureCoord) : paint.PaintUVDirect(brush, hit.textureCoord);
                            break;
                    }
                }
            }
        }
    }
}
