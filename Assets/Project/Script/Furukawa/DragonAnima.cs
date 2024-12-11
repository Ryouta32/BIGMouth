using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnima : MonoBehaviour
{
    Animator anima;
    float time;
    float limit;
    [SerializeField] BetaSpawn spawn;
    void Start()
    {
        limit = Random.Range(0, 10);
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
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
}
