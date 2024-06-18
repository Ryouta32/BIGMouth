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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    bool success = true;
        //    RaycastHit hitInfo;
        //    if (Physics.Raycast(ray, out hitInfo))
        //    {
        //        var paintObject = hitInfo.transform.GetComponent<InkCanvas>();
        //        if (paintObject != null)
        //            switch (useMethodType)
        //            {
        //                case UseMethodType.RaycastHitInfo:

        //                    success = erase ? paintObject.Erase(brush, hitInfo) : paintObject.Paint(brush, hitInfo);
        //                    break;

        //                case UseMethodType.WorldPoint:
        //                    success = erase ? paintObject.Erase(brush, hitInfo.point) : paintObject.Paint(brush, hitInfo.point);
        //                    break;

        //                case UseMethodType.NearestSurfacePoint:
        //                    success = erase ? paintObject.EraseNearestTriangleSurface(brush, hitInfo.point) : paintObject.PaintNearestTriangleSurface(brush, hitInfo.point);
        //                    break;

        //                case UseMethodType.DirectUV:
        //                    if (!(hitInfo.collider is MeshCollider))
        //                        Debug.LogWarning("Raycast may be unexpected if you do not use MeshCollider.");
        //                    success = erase ? paintObject.EraseUVDirect(brush, hitInfo.textureCoord) : paintObject.PaintUVDirect(brush, hitInfo.textureCoord);
        //                    break;
        //            }
        //        if (!success)
        //            Debug.LogError("Failed to paint.");
        //    }
        //}
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        bool success = true;

        if (Physics.Raycast(ray, out hit))
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
