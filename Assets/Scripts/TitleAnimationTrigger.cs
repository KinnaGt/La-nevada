using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimationTrigger : MonoBehaviour
{
    Animator animator;

    public void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
        animator.speed = 0; // Set the speed to 0 to pause the animation
    }

    private void OnMouseDown()
    {
        // Trigger the animation
        TriggerAnimation();
    }

    void TriggerAnimation()
    {
        animator.speed = 1; // Set the speed to 1 to play the animation
        GetComponent<Collider2D>().enabled = false; // Disable the collider to prevent further clicks
    }
}
