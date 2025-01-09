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

    [SerializeField] int fallcount;
    public static int count;

    private void OnCollisionEnter(Collision col)
    {
        PaintManager paintManager = new PaintManager();

        if (col.gameObject.GetComponent<InkCanvas>())
        {
            switch (col.transform.tag)
            {
                case "Wall":
                    //if(count == fallcount)
                    //{
                    //    AudioManager.manager.PlayPoint(AudioManager.manager.data.mushPotan, this.gameObject);
                    //    Debug.Log("なったーーーーーーーー");
                    //    count = 0;
                    //}
                    paintManager.Paint(col, useMethodType, erase, brush, transform, false, col.transform.tag);
                    count++;
                    Destroy(gameObject, 10.0f);
                    break;
                default:
                    Destroy(gameObject, 10.0f);
                    break;
            }
            Destroy(gameObject , 10.0f);
        }
    }
}
