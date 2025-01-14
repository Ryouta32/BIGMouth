using Es.InkPainter.Effective;
using UnityEngine;

public class RoomPlaneScript : MonoBehaviour
{
    [SerializeField, Tooltip("水平な床を見つけたか")]
    private bool _isHitHorizontalPlane;
    [SerializeField, Tooltip("許容する角度の誤差")]
    private float _approximatelyAngle;
    private RaycastHit[] _raycastHits = new RaycastHit[1];
    HeightFluid heightFluid;

    void Start()
    {
        heightFluid = GetComponent<HeightFluid>();
    }
    private void OnCollisionStay(Collision collision)
    {

        var ray = new Ray(collision.transform.position, Vector3.down);
        var hit = Physics.RaycastNonAlloc(ray, _raycastHits, 1.0f);
        if (hit > 0)
        {
            var hitNormal = _raycastHits[0].normal;
            var angle = Vector3.Angle(hitNormal, Vector3.up);
            _isHitHorizontalPlane = angle >= _approximatelyAngle;
        }
        else
        {
            _isHitHorizontalPlane = false;
        }
        if (_isHitHorizontalPlane)
        {
            heightFluid.SetFlowDirection(Vector2.up);
        }
        else
        {
            heightFluid.SetFlowDirection(Vector2.zero);
        }

    }
}
