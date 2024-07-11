using Es.InkPainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour
{
    [System.Serializable]
    public enum UseMethodType
    {
        RaycastHitInfo,
        WorldPoint,
        NearestSurfacePoint,
        DirectUV,
    }

    public void Paint(Collision col, UseMethodType useMethodType, bool erase, Brush brush,Transform tra)
    {
        Vector3 hitPos;
        foreach (ContactPoint point in col.contacts)
        {
            hitPos = point.normal;
            Ray ray = new Ray(tra.position, -hitPos);
            Debug.Log(hitPos);
            if (col.transform.GetComponent<InkCanvas>())
            {
                bool success = true;



                Debug.DrawLine(tra.position, -hitPos, Color.red, 1f);
                foreach (RaycastHit hit in Physics.RaycastAll(ray))
                {

                    InkCanvas paint = hit.transform.GetComponent<InkCanvas>();


                    if (paint != null)
                    {
                        tra.rotation = Quaternion.FromToRotation(tra.up, hit.normal) * tra.rotation;
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
    public void Paint(ParticleCollisionEvent col, UseMethodType useMethodType, bool erase, Brush brush, GameObject obj,Transform tra)
    {
        Vector3 hitPos;
        //foreach (Vector3 point in col.intersection)
        {
            hitPos = col.intersection;
            Ray ray = new Ray(tra.position, hitPos);
            if (obj.GetComponent<InkCanvas>())
            {
                bool success = true;


                Debug.Log(hitPos);

                Debug.DrawLine(tra.position, hitPos, Color.red, 19f);
                hitPos = new Vector3(-hitPos.x, hitPos.y, -hitPos.z);
                RaycastHit hit;
                if(Physics.Raycast(tra.position, -hitPos, out hit, Mathf.Infinity))
                {

                    Debug.Log("êFìhÇÍÇƒÇÈ");
                    InkCanvas paint = hit.transform.GetComponent<InkCanvas>();


                    if (paint != null)
                    {
                        tra.rotation = Quaternion.FromToRotation(tra.up, hit.normal) * tra.rotation;
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
                //}
                //foreach (RaycastHit hit in Physics.RaycastAll(ray))
                //{
                //    Debug.Log("êFìhÇÍÇƒÇÈ");
                //    InkCanvas paint = hit.transform.GetComponent<InkCanvas>();


                //    if (paint != null)
                //    {
                //        tra.rotation = Quaternion.FromToRotation(tra.up, hit.normal) * tra.rotation;
                //        switch (useMethodType)
                //        {
                //            case UseMethodType.RaycastHitInfo:
                //                success = erase ? paint.Erase(brush, hit) : paint.Paint(brush, hit);

                //                break;
                //            case UseMethodType.WorldPoint:
                //                success = erase ? paint.Erase(brush, hit.point) : paint.Paint(brush, hit.point);
                //                break;

                //            case UseMethodType.NearestSurfacePoint:
                //                success = erase ? paint.EraseNearestTriangleSurface(brush, hit.point) : paint.PaintNearestTriangleSurface(brush, hit.point);
                //                break;

                //            case UseMethodType.DirectUV:
                //                if (!(hit.collider is MeshCollider))
                //                    Debug.LogWarning("Raycast may be unexpected if you do not use MeshCollider.");
                //                success = erase ? paint.EraseUVDirect(brush, hit.textureCoord) : paint.PaintUVDirect(brush, hit.textureCoord);
                //                break;
                //        }
                //    }
                }
            }
        }
    }
}
    
