using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypewritingOptions : MonoBehaviour
{
    [SerializeField]
    float typeVelocity = 0.05f;

    List<TextMeshProUGUI> childrens;

    void OnEnable()
    {
        childrens = new List<TextMeshProUGUI>();
        foreach (TextMeshProUGUI text in GetComponentsInChildren<TextMeshProUGUI>())
        {
            childrens.Add(text);
        }
        TypeText();
    }

    void TypeText()
    {
        foreach (TextMeshProUGUI text in childrens)
        {
            text.maxVisibleCharacters = 0;
            StartCoroutine(TypeTextCoroutine(text));
        }
    }

    IEnumerator TypeTextCoroutine(TextMeshProUGUI text)
    {
        for (int i = 0; i < text.text.Length; i++)
        {
            text.maxVisibleCharacters = i + 1;
            yield return new WaitForSeconds(typeVelocity);
        }
    }
}
