using Es.InkPainter;
using UnityEngine;

public class TentaclePaint : MonoBehaviour
{
    [SerializeField]
    private Brush brush;
    [SerializeField]
    private PaintManager.UseMethodType useMethodType = PaintManager.UseMethodType.RaycastHitInfo;
    [SerializeField]
    private PaintManager.UseMethodType DrauseMethodType = PaintManager.UseMethodType.RaycastHitInfo;

    [SerializeField]
    bool erase = false;

    private void OnCollisionEnter(Collision collision)
    {
        PaintManager paintManager = new PaintManager();
        switch (collision.transform.tag)
        {
            case "Wall":
                paintManager.Paint(collision, useMethodType, erase, brush, transform, false, collision.transform.tag);
                break;
            default:
                break;
        }
    }
}
