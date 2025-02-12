﻿using Es.InkPainter;
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

    float time;

    [SerializeField, Range(0, 1)]
    public float Scale = 0.01f;

    void Start()
    {
        time = 0;
        //brush.brushScale = Scale;
    }
    private void OnCollisionStay(Collision collision)
    {
        time += Time.deltaTime;
        if (time >= 0.1f)
        {
            time = 0;

            PaintManager paintManager = new PaintManager();
        Debug.Log(collision.gameObject.name);
            switch (collision.transform.tag)
            {
                case "Dragon":
                    paintManager.Paint(collision, DrauseMethodType, !erase, brush, transform, true, collision.transform.tag);
                    break;
                case "Wall":
                    paintManager.Paint(collision, useMethodType, erase, brush, transform, false, collision.transform.tag);
                    break;
                case "Plane":
                    brush.brushScale = 0.01f;
                    paintManager.Paint(collision, useMethodType, erase, brush, transform, false, collision.transform.tag);
                    break;
                default:
                    break;
            }
        }
        else return;
    }
}
