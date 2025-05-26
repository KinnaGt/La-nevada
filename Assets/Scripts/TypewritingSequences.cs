using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypewritingSequences : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    TextMeshProUGUI nextText;

    [SerializeField]
    float typeSpeed = 0.05f;

    [SerializeField]
    float waitTime = 1f;

    [SerializeField]
    Button nextButton;

    void OnEnable()
    {
        StartCoroutine(TypeTextCoroutine());
    }

    public void ChangeText(string newText)
    {
        text.maxVisibleCharacters = 0;
        text.text = newText;
        StartCoroutine(TypeTextCoroutine());
    }

    IEnumerator TypeTextCoroutine()
    {
        text.maxVisibleCharacters = 0;
        for (int i = 0; i < text.text.Length; i++)
        {
            text.maxVisibleCharacters = i + 1;
            //wait more if is a punctuation
            if (text.text[i] == '.')
            {
                yield return new WaitForSeconds(.5f);
            }
            else if (text.text[i] == ',' || text.text[i] == ':')
            {
                yield return new WaitForSeconds(.25f);
            }
            else
            {
                yield return new WaitForSeconds(typeSpeed);
            }
        }
        yield return new WaitForSeconds(waitTime);
        text.maxVisibleCharacters = text.text.Length;
        if (nextText != null)
        {
            nextText.gameObject.SetActive(true);
        }
        else
        {
            nextButton?.gameObject.SetActive(true);
        }
    }
}
