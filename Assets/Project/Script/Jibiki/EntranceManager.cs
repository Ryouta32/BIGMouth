using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* ドラゴンの登場をスクリプトで制御
 * 音を流してドラゴンのアニメーションさせる */

public class EntranceManager : MonoBehaviour
{
    [SerializeField] AudioClip hibisound;
    AudioManager audioM;
    [SerializeField] Animator animator;

    [SerializeField] float time;

    // Start is called before the first frame update
    void Start()
    {
        audioM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimSet()
    {
        animator.SetTrigger("dragon_BreakIn_Take_001");
        Debug.Log("よんでみた");
    }
}
