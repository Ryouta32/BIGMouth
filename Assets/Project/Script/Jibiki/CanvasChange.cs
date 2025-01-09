using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChange : MonoBehaviour
{
    [SerializeField] GameObject[] Canvas;

    [SerializeField] bool[] Phase; 
    // Start is called before the first frame update
    void Start()
    {
        //Phase = new bool[Canvas.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Canvas.Length; i++)
        {
            if (Phase[i])
            {
                Canvas[i].SetActive(true);
            }
        }
    }
}
