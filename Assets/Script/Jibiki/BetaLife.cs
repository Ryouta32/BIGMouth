using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaLife : MonoBehaviour
{
    [SerializeField] int life = 3;
    [SerializeField] int damage = 1;

    // Update is called once per frame
    void Update()
    {
        if(life < 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        life -= damage;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Brush"))
        {
            Damage(damage);
        }
    }
}
