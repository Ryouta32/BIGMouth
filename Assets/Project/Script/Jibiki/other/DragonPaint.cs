using Es.InkPainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPaint : MonoBehaviour
{
    float time = 0;

    [SerializeField]
    private Brush brush;
    [SerializeField]
    private PaintManager.UseMethodType useMethodType = PaintManager.UseMethodType.RaycastHitInfo;
    [SerializeField]
    private PaintManager.UseMethodType DrauseMethodType = PaintManager.UseMethodType.RaycastHitInfo;
    [SerializeField]
    bool erase = false;

    private bool col = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.blue);
        if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out hit, 100.0f))
        {
            Debug.Log("あたったよ");
            if (hit.collider.tag == "Dragon")
            {
                PaintManager paintManager = new PaintManager();

                paintManager.Paint(hit.collider, useMethodType, erase, brush, transform, false, hit.collider.transform.tag);
                Debug.Log("塗ったよ");
            }
        }
    }
}
