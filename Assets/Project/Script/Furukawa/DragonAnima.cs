using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnima : MonoBehaviour
{
    Animator anima;
    float time;
    float limit;
    [SerializeField] BetaSpawn spawn;

    [SerializeField] float tobidasi;
    bool isCalled = false;

    void Start()
    {
        limit = Random.Range(0, 10);
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > tobidasi && isCalled == false)
        {
            isCalled = true;
            tobidasiAnim();
        }

        if (time >= limit)
        {
            anima.SetTrigger("Cough");
            time = 0;
            limit = Random.Range(0, 10);
        }

    }
    public void Spawn()
    {
        //spawn.StartSpawan();
    }

    public void tobidasiAnim()
    {
        anima.SetTrigger("dragon_Breakin_Take_001");
    }
}
