using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//それぞれのTrigger
//Abare
//Attack
//Attack2
//Break
public class BIGEnemyAnima : MonoBehaviour
{
    [SerializeField] BigEnemyScript bigSc;
    [SerializeField][Tooltip("上から順番に出てくる")] List<GameObject> Enemys;
    private int count = 0;
    Animator anima;
    string abareruStr="Abare";
    string attackStr= "Attack";
    string attack2Str= "Attack2";
    string breakStr= "Break";
    float time=0;
    float limit;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        setLimit();
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time > limit)
        {
            float x = Random.Range(0, 3);
            switch (x)
            {
                case 0:
                    Attack();
                    break;
                case 1:
                    Attack2();
                    break;
                case 2:
                    Abare();
                    break;
            }
            setLimit();
        }
        if (count >= 2)
        {
            bigSc.Erase();
        }
    }
    private void setLimit()
    {
        limit = Random.Range(5, 10);
        time = 0;
            }
    public void Break()
    {
        bigSc.Spawn(Enemys[count]);
        anima.SetTrigger(breakStr);
        count++;
    }
    public void Attack()
    {
        anima.SetTrigger(attackStr);
    }
    public void Attack2()
    {
        anima.SetTrigger(attack2Str);
    }
    public void Abare()
    {
        anima.SetTrigger(abareruStr);
    }
}
