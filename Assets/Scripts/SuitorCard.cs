using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitorCard : CharacterCard
{
    private Animator animator;
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (animator != null) {
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Destroy")) Destroy(gameObject);
        }
    }
    
    public void SetOnScreen() {
        animator.SetBool("onscreen", true);
    }

    public void SetRejected() {
        animator.SetBool("rejected", true);
    }

    public void SetAccepted() {
        animator.SetBool("accepted", true);
    }
}
