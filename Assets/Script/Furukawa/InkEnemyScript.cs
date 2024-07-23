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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude <= 5f&&col)
        {
            rb.AddForce(power);

        }
        StartCoroutine("comp");
    }
    IEnumerator comp()
    {
        yield return new WaitForSeconds(2f);
        power = power * -1;
        rb.velocity =Vector3.zero ;

    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 hitPos;
        RaycastHit hit;
        bool success = true;
        col = true;

        PaintManager paintManager = new PaintManager();

        paintManager.Paint(collision, useMethodType, erase, brush, transform,false);
       
        }
}
