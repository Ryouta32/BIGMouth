using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIGEnemyWeekPoint : MonoBehaviour
{
    [SerializeField] BigEnemyScript bigSC;
    [SerializeField] GameObject Yogore;
    private int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Brush")
        {
        Debug.Log(other.gameObject.name);
            count++;
            if (count >= bigSC.rubCount) { 
                //爆発
                for(int i = 0; i < bigSC.dirtCount; i++)
                {
                    GameObject obj = Instantiate(Yogore,other.ClosestPointOnBounds(this.transform.position), Quaternion.identity);
                    obj.GetComponent<BIGEnemyChaildSC>().destination = transform.position;
                    obj.GetComponent<BIGEnemyChaildSC>().biSC = bigSC;
                    Vector3 dir = new Vector3(Random.Range(-1f, 1f)*transform.forward.x, Random.Range(-1f, 1f)*transform.forward.y, Random.Range(-1f, 1f)*transform.forward.z).normalized;
                    Debug.Log(dir);
                    obj.GetComponent<Rigidbody>().AddForce(dir * 300f);
                    bigSC.OBJScaleDown();
                }
            }
        }
    }
}
