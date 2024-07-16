using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class bouScript : MonoBehaviour
{
    [SerializeField] OVRCameraRig ovr;
    Vector3 move;
    Vector3 oldPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position= ovr.rightHandAnchor.position;
        oldPos = ovr.rightHandAnchor.position;
    }

    // Update is called once per frame
    void Update()
    {
        move = oldPos -= ovr.rightHandAnchor.position;
        transform.position -= move;

        transform.LookAt(ovr.leftHandAnchor.position);
        oldPos= ovr.rightHandAnchor.position;
        LogSC.log = move.ToString()+"\n"+transform.position.ToString();
    }

    public Vector3 pos => ovr.leftHandAnchor.position - ovr.rightHandAnchor.position;

}
