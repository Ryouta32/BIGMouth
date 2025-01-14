using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;

public class ShowerEffect : MonoBehaviour
{
    [SerializeField] GameObject PaintObj;
    private ParticleSystem p_RefParticle;
    [SerializeField, Tooltip("ヒット位置の通知")]
    private List<ParticleCollisionEvent> p_CollisionEventList;

    [SerializeField] int fallcount;
    int count;
    private void Start()
    {
        p_RefParticle = GetComponent<ParticleSystem>();
        p_CollisionEventList = new List<ParticleCollisionEvent>();
    } 
    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log("わあ");

        PaintManager paintManager = new PaintManager();

        if (other.gameObject.GetComponent<InkCanvas>())
        {
            p_RefParticle.GetCollisionEvents(other, p_CollisionEventList);
            foreach (ParticleCollisionEvent collisionEvent in p_CollisionEventList)
            {
                Vector3 pos = collisionEvent.intersection;
                //Debug.Log("Particle Hit : object name = " + other.name + ", position = " + pos.ToString());

                Instantiate(PaintObj, pos, Quaternion.identity);
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
    }
}
