using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* ドラゴンが壁に当たったらドラゴンオブジェクト表示させる */

public class SetActiveScript : MonoBehaviour
{
    [SerializeField] Renderer[] renderers;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sound1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MIMIC"))
        {
            audioSource.PlayOneShot(sound1);

            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].enabled = true;
            }
        }
    }
}