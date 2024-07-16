using Es.InkPainter;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static PaintManager;
using static UnityEngine.ParticleSystem;

public class ShowerScript : MonoBehaviour
{
    [SerializeField]
    private Brush brush;

    [SerializeField]
    private PaintManager.UseMethodType useMethodType = PaintManager.UseMethodType.RaycastHitInfo;

    [SerializeField]
    bool erase = false;
    public List<ParticleCollisionEvent> collisionEvents;
    private ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
        particle = this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnParticleCollision(GameObject obj)
    {
        particle.GetCollisionEvents(obj, collisionEvents);
        foreach (var collisionEvent in collisionEvents)
        {
            //var col = collisionEvent.colliderComponent;
        PaintManager pManager = new PaintManager();
            //Debug.Log("“–‚½‚Á‚Ä‚¢‚é‚ÅŒã˜a‘f");
            //Collision col = obj.GetComponent<Collision>();
            pManager.Paint(collisionEvent, useMethodType, erase, brush,obj,transform);
        }
    }
}
