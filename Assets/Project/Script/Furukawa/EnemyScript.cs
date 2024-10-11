using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    BetaLife betaLife;
    EnemyManager manager;
    public BouSakiScript bouSaki;
    private void Start()
    {
        initialization();
    }
    private void Update()
    {
        Vector3 diff = bouSaki.gameObject.transform.position - transform.position;
        if (diff.magnitude < bouSaki.GetInhaleDis()&&bouSaki.GetInHale())
        {
            //‹z‚¢ž‚Ý‚Ìˆ—
            transform.position = Vector3.MoveTowards(transform.position, bouSaki.gameObject.transform.position, bouSaki.GetInHaleSpeed());
        }
    }
    public void initialization()
    {
        Debug.Log(GameObject.Find("Stick").gameObject.name);
        bouSaki = GameObject.Find("Stick").GetComponent<bouScript>().GetSaki();
    }
    public void setManager(EnemyManager x) => manager = x;
    public void destroyObj() => manager.DestroyEnemys(this.gameObject);
}
