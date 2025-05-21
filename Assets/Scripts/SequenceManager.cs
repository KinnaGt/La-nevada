using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceManager : MonoBehaviour
{
    [SerializeField]
    TextContainer textContainer;

    [SerializeField]
    Button nextButton;

    Animator animator;

    [SerializeField]
    int currentSequenceID = 1;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void NextSequence()
    {
        textContainer.HideTexts(currentSequenceID);
        currentSequenceID++;
        nextButton.gameObject.SetActive(false);

        animator.SetTrigger("Next");
    }

    public void ShowNextNext()
    {
        textContainer.ShowText(currentSequenceID);
    }

    public void ShowNextButton()
    {
        nextButton.gameObject.SetActive(true);
    }
}
