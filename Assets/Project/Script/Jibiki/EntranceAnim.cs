using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceAnim : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Dragon_Mix999").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimStart()
    {
        //animator.SetTrigger("dragon_Breakin_Take_001");
    }
}
