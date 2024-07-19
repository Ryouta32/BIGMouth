using Es.InkPainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager 
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
            if (col.transform.GetComponent<InkCanvas>())
            {
                bool success = true;



                foreach (RaycastHit hit in Physics.RaycastAll(ray))
                {

                    Debug.DrawLine(tra.position, -hitPos, Color.red, 1f);
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
            hitPos = col.intersection;
            if (obj.GetComponent<InkCanvas>())
            {
                bool success = true;

                RaycastHit hit;

            Ray ray = new Ray(tra.position, tra.TransformDirection(hitPos));

            Debug.Log(ray);
            if (Physics.Raycast(ray,out hit,Mathf.Infinity))
                {
                var dir = ray.origin + ray.direction * hit.distance;

                Debug.DrawLine(tra.position, dir, Color.red, 1f);

                Debug.Log("UV" + hit.textureCoord);
                Debug.Log("point" + hit.point);
                InkCanvas paint = hit.transform.GetComponent<InkCanvas>();


                ////Debug.Log(hit.transform.gameObject.name);
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
