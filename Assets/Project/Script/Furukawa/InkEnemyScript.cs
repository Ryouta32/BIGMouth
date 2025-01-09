using Es.InkPainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkEnemyScript : MonoBehaviour
{

    [SerializeField]
    private Brush brush;

    [SerializeField]
    private PaintManager.UseMethodType useMethodType = PaintManager.UseMethodType.RaycastHitInfo;
    [SerializeField]
    private PaintManager.UseMethodType DrauseMethodType = PaintManager.UseMethodType.RaycastHitInfo;

    [SerializeField]
    bool erase = false;

    private bool col=false;
    Vector3 power=new Vector3(-2,0,0);
    float time;

    void Start()
    {
        time = 0;
    }
    private void OnCollisionStay(Collision collision)
    {
        time += Time.deltaTime;
        if (time >= 0.1f)
        {
            time = 0;
            col = true;

            PaintManager paintManager = new PaintManager();
            switch (collision.transform.tag)
            {
                case "Dragon":
                    paintManager.Paint(collision, DrauseMethodType, !erase, brush, transform, true, collision.transform.tag);
                    break;
                case "Wall":
                    paintManager.Paint(collision, useMethodType, erase, brush, transform, false, collision.transform.tag);
                    break;
                default:
                    break;
            }
        }
        else return;
    }
}
