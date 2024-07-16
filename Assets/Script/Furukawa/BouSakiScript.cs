using Es.InkPainter;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BouSakiScript : MonoBehaviour
{

    [SerializeField] bouScript bouSC;

    [SerializeField]
    private Brush brush;

    [SerializeField]
    private PaintManager.UseMethodType useMethodType = PaintManager.UseMethodType.RaycastHitInfo;

    [SerializeField]
    bool erase = false;

    [SerializeField]
    TextMeshProUGUI text;
    float time;

    [SerializeField] private OVRInput.RawButton actionBtn;

    [SerializeField] GameObject ShowerObj;
    [SerializeField] GameObject showerCube;
    private GameObject currentBall;
    [SerializeField] float power;

    bool on=true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (on&&OVRInput.Get(actionBtn)|| (on && Input.GetKey(KeyCode.Space)))
        {
            ShowerObj.SetActive(true);
            StartCoroutine("ShowerTime");
        }
        if (OVRInput.GetUp(actionBtn) || Input.GetKeyUp(KeyCode.Space))
        {
            ShowerObj.SetActive(false);
            StopCoroutine("ShowerTime");
            on = true;
        }
    }
    IEnumerator ShowerTime()
    {
        on = false;
        yield return new WaitForSeconds(0.2f);

        GameObject obj;
        obj = Instantiate(showerCube, transform.position, Quaternion.identity);
        obj.GetComponent<Rigidbody>().AddForce( bouSC.pos.normalized*power);
        on = true;
    }
    private void OnCollisionStay(Collision other)
    {
        PaintManager pManager = new PaintManager();
        pManager.Paint(other, useMethodType, erase, brush,transform);
    }
}
