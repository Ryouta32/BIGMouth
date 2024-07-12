using Es.InkPainter;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BouSakiScript : MonoBehaviour
{

    [SerializeField] bouScript bouSC;
    [SerializeField] Material material;

    [SerializeField]
    private Brush brush;

    [SerializeField]
    private PaintManager.UseMethodType useMethodType = PaintManager.UseMethodType.RaycastHitInfo;

    [SerializeField]
    bool erase = false;

    [SerializeField]
    TextMeshProUGUI text;
    float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision other)
    {
        PaintManager pManager = new PaintManager();
        pManager.Paint(other, useMethodType, erase, brush,transform);
    }
}
