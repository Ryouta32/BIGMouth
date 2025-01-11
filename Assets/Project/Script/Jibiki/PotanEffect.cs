using Es.InkPainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotanEffect : MonoBehaviour
{
    [SerializeField]
    private Brush brush;

    [SerializeField]
    private PaintManager.UseMethodType useMethodType;

    [Tooltip("trueだと汚れる")]
    [SerializeField]
    bool erase = false;

    private void OnCollisionEnter(Collision col)
    {
        PaintManager paintManager = new PaintManager();

        if (col.gameObject.GetComponent<InkCanvas>())
        {
            switch (col.transform.tag)
            {
                case "Wall":
                    paintManager.Paint(col, useMethodType, erase, brush, transform, false, col.transform.tag);
                    Destroy(gameObject, 1.0f);
                    break;
                default:
                    Destroy(gameObject, 1.0f);
                    break;
            }
            Destroy(gameObject , 1.0f);
        }
    }
}
