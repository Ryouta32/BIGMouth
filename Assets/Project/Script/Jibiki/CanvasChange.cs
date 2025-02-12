﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChange : MonoBehaviour
{
    [SerializeField] GameObject[] Canvas;

    [SerializeField] public bool[] Phase;

    public void CanvasActive()
    {
        for (int i = 0; i < Canvas.Length; i++)
        {
            Canvas[i].SetActive(Phase[i]);
        }
    }
}
