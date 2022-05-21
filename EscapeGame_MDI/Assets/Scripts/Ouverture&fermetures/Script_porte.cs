using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_porte : MonoBehaviour
{
    public Animator animator;
    public bool open;

    void FixedUpdate()
    {
        animator.SetBool("open", open);
    }
    

}

