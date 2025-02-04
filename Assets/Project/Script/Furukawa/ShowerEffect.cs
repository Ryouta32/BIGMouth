using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;

public class ShowerEffect : MonoBehaviour
{
    [SerializeField] GameObject[] PaintObj;
    private ParticleSystem p_RefParticle;
    [SerializeField, Tooltip("ヒット位置の通知")]
    private List<ParticleCollisionEvent> p_CollisionEventList;

    [SerializeField] int fallcount;
    int count;
    int i = 0;
    private void Start()
    {
        p_RefParticle = GetComponent<ParticleSystem>();
        p_CollisionEventList = new List<ParticleCollisionEvent>();
    } 
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.gameObject.name+ other.GetComponent<BIGEnemyWeekPoint>());

        PaintManager paintManager = new PaintManager();

        if (other.gameObject.GetComponent<InkCanvas>())
        {
            p_RefParticle.GetCollisionEvents(other, p_CollisionEventList);
            foreach (ParticleCollisionEvent collisionEvent in p_CollisionEventList)
            {
                Vector3 pos = collisionEvent.intersection;
                //Debug.Log("Particle Hit : object name = " + other.name + ", position = " + pos.ToString());
                if(PaintObj.Length == 1)
                {
                    Instantiate(PaintObj[0], pos, Quaternion.identity);
                }
                else
                {
                    if (i > 2)
                    {
                        i = 0;
                    }
                    Instantiate(PaintObj[i], pos, Quaternion.identity);
                    i++;
                }
                count++;

                if (gameObject.tag == "Normal" && count == fallcount)
                {
                    AudioManager.manager.PlayPoint(AudioManager.manager.data.mushPotan, this.gameObject);
                    count = 0;
                }
                // 今回は1つ目のヒット情報のみ処理する
                break;
            }
        }
        if (other.GetComponent<BIGEnemyWeekPoint>())
        {
            p_RefParticle.GetCollisionEvents(other, p_CollisionEventList);
            Debug.Log("waa");
            foreach (ParticleCollisionEvent collisionEvent in p_CollisionEventList)
            {

                other.GetComponent<BIGEnemyWeekPoint>().Damage();
                // 今回は1つ目のヒット情報のみ処理する
                break;
            }
        }
    }
}
