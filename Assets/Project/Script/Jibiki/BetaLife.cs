using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaLife : MonoBehaviour
{
    [SerializeField] int life = 3;
    [SerializeField] int damage = 1;
    private EnemyScript enemySC;

    private void Start()
    {
        enemySC = GetComponent<EnemyScript>();
    }
    void Update()
    {
        if(life < 0)
        {
            enemySC.destroyObj();
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
