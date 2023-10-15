using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShineEffect : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

        InvokeRepeating("PlayAnimation", 0f, 3f);
    }

    void PlayAnimation()
    {
        animator.SetTrigger("Shine");
    }
}
