using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//それぞれのTrigger
//Damage
public class BIGEnemyAnima : MonoBehaviour
{
    [SerializeField] BigEnemyScript bigSc;
    [SerializeField] GameObject tentacle;
    [SerializeField] GameObject mush;
    [SerializeField] ParticleSystem third;
    [SerializeField] ParticleSystem forth;
    private Vector3 tentaPos;
    private Vector3 mushPos;
    private int count = 0;
    Animator anima;
    string DamageStr="Damage";
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        tentaPos = GameObject.Find("TentaPos").transform.position;
        tentaPos = GameObject.Find("MushPos").transform.position;
    }

    private void Update()
    {

        if (count >= 2)
        {
            bigSc.Erase();
        }
    }
    public void Break()
    {
        count++;
        anima.SetTrigger(DamageStr);

    }
    public void Damage()
    {
        anima.SetTrigger(DamageStr);
        //anima.SetTrigger(abareruStr);
    }

    public void fast()
    {
        Instantiate(tentacle, tentaPos, Quaternion.identity);
    }
    public void second()
    {
        Instantiate(mush, mushPos, Quaternion.identity);
    }
    public void thirdAttack()
    {
        third.Play();
    }
    public void thirdAttackStop()
    {
        third.Stop();
    }
    public void forthAttack()
    {
        forth.Play();
    }
    public void forthAttackStop()
    {
        forth.Stop();
    }
}
