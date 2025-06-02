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
        #region Special Cases
        if (currentSequenceID < 8 || currentSequenceID > 10)
        {
            textContainer.HideTexts(currentSequenceID);
        }
        if (currentSequenceID == 10)
        {
            textContainer.HideTexts(currentSequenceID - 1);
            textContainer.HideTexts(currentSequenceID - 2);
            textContainer.HideTexts(currentSequenceID);
        }
        #endregion

        currentSequenceID++;
        nextButton.gameObject.SetActive(false);

        animator.SetTrigger("Next");
    }

    public void ShowNextText()
    {
        textContainer.ShowText(currentSequenceID);
    }

    public void ShowNextButton()
    {
        nextButton.gameObject.SetActive(true);
    }

    public void ShowTrucoOptions()
    {
        textContainer.ShowTrucoOptions();
    }

    public void ReproduceSfx(int index)
    {
        SfxManager.Instance.PlaySfx(index);
    }
}
