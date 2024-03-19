using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltAnim : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void setAnim()
    {
        animator.SetBool("back", true);
    }

    public void backAnim()
    {
        animator.SetBool("back", false);
    }
}
