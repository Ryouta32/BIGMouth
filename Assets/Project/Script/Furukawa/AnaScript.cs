using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaScript : MonoBehaviour
{
    [SerializeField] tutorialWall wallSc;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ShowerCube>())
            wallSc.holeHit();
    }
}
