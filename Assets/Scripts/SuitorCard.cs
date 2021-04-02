using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitorCard : CharacterCard
{
    private Animator animator;
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() {
        if(animator != null && animator.GetCurrentAnimatorStateInfo(0).IsName("OffScreen")) Destroy(gameObject);
    }
    
    public void SetOnScreen() {
        animator.SetBool("onscreen", true);
    }

    public void SetRejected() {
        animator.SetBool("rejected", true);
    }
}
