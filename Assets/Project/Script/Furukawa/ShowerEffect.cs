using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;
using static PaintManager;
using Es.InkPainter;

public class ShowerEffect : MonoBehaviour
{
    [SerializeField]
    private Brush brush;
    [SerializeField]
    private Brush draBrush;

    [SerializeField]
    private PaintManager.UseMethodType useMethodType = PaintManager.UseMethodType.RaycastHitInfo;

    [SerializeField]
    bool erase = false;
    [SerializeField] GameObject PaintObj;
    [SerializeField] string DragonTag = "Dragon";
    private ParticleSystem p_RefParticle;
    [SerializeField, Tooltip("ヒット位置の通知")]
    private List<ParticleCollisionEvent> p_CollisionEventList;

    private void Start()
    {
        p_RefParticle = GetComponent<ParticleSystem>();
        p_CollisionEventList = new List<ParticleCollisionEvent>();
    } 
    private void OnParticleCollision(GameObject other)
    {
        PaintManager paintManager = new PaintManager();

        if (other.gameObject.GetComponent<InkCanvas>())
        {
            p_RefParticle.GetCollisionEvents(other, p_CollisionEventList);
            foreach (ParticleCollisionEvent collisionEvent in p_CollisionEventList)
            {
                Vector3 pos = collisionEvent.intersection;
                //Debug.Log("Particle Hit : object name = " + other.name + ", position = " + pos.ToString());

                Instantiate(PaintObj, pos, Quaternion.identity);
                // 今回は1つ目のヒット情報のみ処理する
                break;
            }
        }
    }
}
