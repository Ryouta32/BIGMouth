using UnityEngine;

public class bouScript : MonoBehaviour
{
    [SerializeField] OVRCameraRig ovr;
    [SerializeField] BouSakiScript saki;
    [SerializeField] Vector3 offset;
    Vector3 move;
    Vector3 oldPos;
    Vector3 hitpos;
    void Start()
    {
        transform.position = ovr.rightHandAnchor.position;
        oldPos = ovr.rightHandAnchor.position;
    }
    void Update()
    {
        move = (oldPos - ovr.rightHandAnchor.position);

        float dis = Vector3.Distance(saki.GetHit(), ovr.rightHandAnchor.position);

        move = hit();
        LogSC.log = transform.position.ToString();
        transform.position -= move;
        Vector3 pos = new Vector3(ovr.leftHandAnchor.position.x, ovr.leftHandAnchor.position.y * offset.y, ovr.leftHandAnchor.position.z);
        transform.LookAt(pos);
        oldPos = ovr.rightHandAnchor.position;
    }

    private Vector3 hit()
    {
        Vector3 pos = oldPos - ovr.rightHandAnchor.position;

        if (saki.GetHit() == Vector3.zero)
            return oldPos - ovr.rightHandAnchor.position;
        float hitdis = Vector3.Distance(hitpos, saki.GetHit()); ;

        return pos;
    }

    public void HitPos() => hitpos = oldPos - ovr.rightHandAnchor.position;
    public void ExisPos() => transform.position = ovr.rightHandAnchor.position;
    public BouSakiScript GetSaki() => saki;
}
