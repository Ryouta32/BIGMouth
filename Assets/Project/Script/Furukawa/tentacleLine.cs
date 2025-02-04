using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacleLine : MonoBehaviour
{
    lightLine lightLine;
    [SerializeField] Transform pos;

    public void setPos()
    {
        if(lightLine!=null)
        lightLine.setPos((pos.position - lightLine.transform.position)+(Vector3.up/2));
    }
    public void SetLine(lightLine x)
    {
        lightLine = x;
        StartCoroutine("sta");
    }
    IEnumerator sta()
    {
        yield return new WaitForSeconds(0.5f);
        setPos();
    }
}
