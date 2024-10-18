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
    bool erase = false;

    Rigidbody rb;
    private bool col=false;
    Vector3 power=new Vector3(-2,0,0);
    float time;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = 0;
    }
    private void OnCollisionStay(Collision collision)
    {
        time += Time.deltaTime;
        if (time >= 0.4)
        {
            time = 0;
            col = true;

            PaintManager paintManager = new PaintManager();

            paintManager.Paint(collision, useMethodType, erase, brush, transform ,false, collision.transform.tag);

        }
        else return;
    }
}
