using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class bouScript : MonoBehaviour
{
    [SerializeField] OVRCameraRig ovr;
    [SerializeField] BouSakiScript saki;
    Vector3 move;
    Vector3 oldPos;
    Vector3 hitpos;
    float Hitdis =0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position= ovr.rightHandAnchor.position;
        oldPos = ovr.rightHandAnchor.position;
    }

    // Update is called once per frame
    void Update()
    {
        move = (oldPos - ovr.rightHandAnchor.position);

        float dis = Vector3.Distance(saki.GetHit() , ovr.rightHandAnchor.position);

        move = hit();

        //if(Hitdis<dis)
        {
            transform.position -= move;

            transform.LookAt(ovr.leftHandAnchor.position);

        }
        //else
        //{
        //    move = hit();
        //    transform.position -= move;

        //    transform.LookAt(ovr.leftHandAnchor.position);
        //}
        oldPos= ovr.rightHandAnchor.position;
    }

    private Vector3 hit()
    {
        Vector3 pos = oldPos - ovr.rightHandAnchor.position;

        if (saki.GetHit() == Vector3.zero)
            return oldPos - ovr.rightHandAnchor.position;

        //Vector3[] temp = { new Vector3(1, 1, 1), new Vector3(1, 1, 0), new Vector3(1, 0, 1), new Vector3(0, 1, 1), new Vector3(0, 1, 0), new Vector3(0, 0, 1), };
        float hitdis = Vector3.Distance(hitpos, saki.GetHit()); ;
       
        //for (int i=0;i< temp.Length; i++)
        //{
        //    Vector3 a = new Vector3(move.x * temp[i].x, move.y* temp[i].y, move.z* temp[i].z);
        //float dis = Vector3.Distance(a, saki.GetHit() );

        //    if (dis > hitdis)
        //    {
        //        DebugText.LogText.Log(temp[i]);

        //        return Vector3.Scale(temp[i], oldPos - ovr.rightHandAnchor.position);
        //    }
        //}

        return pos;
    }

    public Vector3 pos => ovr.leftHandAnchor.position - ovr.rightHandAnchor.position;


    public void HitPos() => hitpos = oldPos- ovr.rightHandAnchor.position;
    public void ExisPos() => transform.position = ovr.rightHandAnchor.position;


}
