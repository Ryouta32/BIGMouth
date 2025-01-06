using Es.InkPainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSekikomi : MonoBehaviour
{
    [SerializeField] GameObject Beta;
    ParticleSystem p_system;
    private List<ParticleCollisionEvent> p_CollisionEventList;

    private void Start()
    {
        p_system = GetComponent<ParticleSystem>();
        p_CollisionEventList = new List<ParticleCollisionEvent>();
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);

        if(other.name == "Cube.1")
        {
            p_system.GetCollisionEvents(other, p_CollisionEventList);
            foreach (ParticleCollisionEvent collisionEvent in p_CollisionEventList)
            {
                Vector3 pos = collisionEvent.intersection;
                Instantiate(Beta, pos, Quaternion.identity);
                // 今回は1つ目のヒット情報のみ処理する
                break;
            }
            Destroy(gameObject);
        }
    }
}
