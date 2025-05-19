using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimationTrigger : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    GameObject titleOptions;

    public void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0;
    }

    private void OnMouseDown()
    {
        TriggerAnimation();
    }

    void TriggerAnimation()
    {
        animator.speed = 1;
        GetComponent<Collider2D>().enabled = false;
    }

    void TriggerOptions()
    {
        titleOptions.SetActive(true);
    }
}
