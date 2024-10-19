using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* ドラゴンが壁に当たったらドラゴンオブジェクト表示させる */

public class SetActiveScript : MonoBehaviour
{
    [SerializeField] Renderer[] renderers;

    public AudioClip sound1;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MIMIC"))
        {
            audioSource.PlayOneShot(sound1);

            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].enabled = true;
            }
        }
    }
}
