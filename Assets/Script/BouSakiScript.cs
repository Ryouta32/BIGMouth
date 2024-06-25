using Es.InkPainter;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouSakiScript : MonoBehaviour
{
    [System.Serializable]
    private enum UseMethodType
    {
        RaycastHitInfo,
        WorldPoint,
        NearestSurfacePoint,
        DirectUV,
    }
    [SerializeField] bouScript bouSC;
    [SerializeField] Material material;

    [SerializeField]
    private Brush brush;

    [SerializeField]
    private UseMethodType useMethodType = UseMethodType.RaycastHitInfo;

    [SerializeField]
    bool erase = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "HA")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        if (other.transform.GetComponent<InkCanvas>())
        {
            bool success = true;
            Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);

            Ray ray = new Ray(transform.position, -hitPos);

            foreach (RaycastHit hit in Physics.RaycastAll(ray))
            {
                InkCanvas paint = hit.transform.GetComponent<InkCanvas>();

                if (paint != null)
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
