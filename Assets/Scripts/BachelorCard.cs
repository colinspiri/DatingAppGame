using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BachelorCard : CharacterCard
{
    private Animator animator;
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    
    private void Update() {
        if (animator != null) {
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("OffScreen")) Destroy(gameObject);
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Destroy")) Destroy(gameObject);
        }
    }

    public void SetAccepted() {
        animator.SetBool("accepted", true);
    }
}
