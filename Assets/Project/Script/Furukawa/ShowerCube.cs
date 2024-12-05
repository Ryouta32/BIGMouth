﻿using Es.InkPainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PaintManager;

public class ShowerCube : MonoBehaviour
{
    [SerializeField]
    private Brush brush;
    [SerializeField]
    private Brush draBrush;

    [SerializeField]
    private PaintManager.UseMethodType useMethodType = PaintManager.UseMethodType.RaycastHitInfo;

    [SerializeField]
    bool erase = false;
    [SerializeField] string DragonTag = "Dragon";

    private float time;
    string _tag;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 01f)
        {
            //Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        PaintManager paintManager = new PaintManager();
        if (col.gameObject.GetComponent<InkCanvas>())
        {

            switch (col.transform.tag)
            {
                case "Dragon":
                    paintManager.Paint(col, useMethodType, !erase, draBrush, transform, true, DragonTag);
                    break;
                case "Wall":
                    paintManager.Paint(col, useMethodType, erase, brush, transform, true, DragonTag);
                    break;
            }

            Destroy(gameObject);
        }
    }

    public void setTag(string s) => _tag = s;
}
