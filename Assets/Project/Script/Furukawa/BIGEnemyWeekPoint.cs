﻿using UnityEngine;

public class BIGEnemyWeekPoint : MonoBehaviour
{
    [SerializeField] BigEnemyScript bigSC;
    [SerializeField] bool barrier = false;
    private int count = 0;
    private void OnTriggerEnter(Collider other)
    {
    }
    private void OnCollisionEnter(Collision other)
    {

            if (other.transform.tag == "Brush")
            {
                Damage();
            }
    }
    public void Damage()
    {
        if (bigSC.GetInvincible())
            return;
            count++;
        if (count >= bigSC.rubCount)
        {
            //爆発
            //for (int i = 0; i < bigSC.dirtCount; i++)
            //{
            //    GameObject obj = Instantiate(Yogore, other.ClosestPointOnBounds(this.transform.position), Quaternion.identity);
            //    obj.GetComponent<BIGEnemyChaildSC>().destination = transform.position;
            //    obj.GetComponent<BIGEnemyChaildSC>().biSC = bigSC;
            //    Vector3 dir = new Vector3(Random.Range(-1f, 1f) * transform.forward.x, Random.Range(-1f, 1f) * transform.forward.y, Random.Range(-1f, 1f) * transform.forward.z).normalized;
            //    obj.GetComponent<Rigidbody>().AddForce(dir * 300f);
            //    //bigSC.OBJScaleDown();
            //}
            bigSC.WeekBreak(barrier);
            AudioManager.manager.PlayPoint(AudioManager.manager.data.gyaon, transform.parent.gameObject);
            Destroy(gameObject);
        }
        else
        {
            AudioManager.manager.PlayPoint(AudioManager.manager.data.damage, this.gameObject);
        }
    }
    public void SetBig(BigEnemyScript big) => bigSC = big;
}
