using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrucoOptions : MonoBehaviour
{
    #region Variables
    [SerializeField]
    TypewritingSequences lucasText;

    [SerializeField]
    TypewritingSequences polskyText;

    [SerializeField]
    TypewritingSequences offText;

    [SerializeField]
    GameObject firstOptions;

    [SerializeField]
    Button trucoButton;

    [SerializeField]
    Button NoQuieroButton;

    [SerializeField]
    Button NoQuieroRealButton;

    [SerializeField]
    SpriteRenderer polskyImage;

    [SerializeField]
    SpriteRenderer lucasImage;

    [SerializeField]
    Animator sequenceAnimator;

    [SerializeField]
    GameObject secondOptions;

    bool secondFlag = false;
    #endregion

    #region First Options
    public void Truco()
    {
        lucasText.ChangeText("Pero... ¿Vos sos boludo Juan? No se puede cantar truco en un envido");
        firstOptions.SetActive(false);

        trucoButton.interactable = false;
        string newText =
            "<s>" + trucoButton.gameObject.GetComponent<TextMeshProUGUI>().text + "</s>";
        trucoButton.gameObject.GetComponent<TextMeshProUGUI>().text = newText;

        Destroy(trucoButton.GetComponent<ButtonManager>());
        Invoke("ShowEnvidoOptions", 5f);
    }

    void ShowEnvidoOptions()
    {
        sequenceAnimator.enabled = true;
        lucasText.ChangeText("Cantá vos que ando flojo.");
        firstOptions.SetActive(true);
    }

    public void NoQuiero()
    {
        sequenceAnimator.enabled = false;
        lucasText.ChangeText("");
        polskyText.ChangeText("Sabíamos que no te daba el cuero, Juan.");

        firstOptions.SetActive(false);
        NoQuieroButton.interactable = false;
        string newText =
            "<s>" + NoQuieroButton.gameObject.GetComponent<TextMeshProUGUI>().text + "</s>";
        NoQuieroButton.gameObject.GetComponent<TextMeshProUGUI>().text = newText;

        Destroy(NoQuieroButton.GetComponent<ButtonManager>());
        Invoke("ShowOffText", 3f);
    }

    public void ShowOffText()
    {
        polskyText.ChangeText("");
        FadeImages();
        offText.gameObject.SetActive(true);
        Invoke("HideOffText", 5f);
    }

    public void HideOffText()
    {
        FadeImages(false);
        offText.gameObject.SetActive(false);
        lucasText.ChangeText("¿Qué te pasa Juan? ¿No querés jugar?");
        polskyText.ChangeText("Envido! Vamos, no seas cagón!");
        if (!secondFlag)
            firstOptions.SetActive(true);
        else
            secondOptions.SetActive(true);
    }

    void FadeImages(bool fadeOut = true)
    {
        float targetAlpha = fadeOut ? 0f : 1f;
        StartCoroutine(FadeImage(polskyImage, targetAlpha));
        StartCoroutine(FadeImage(lucasImage, targetAlpha));
    }

    IEnumerator FadeImage(SpriteRenderer image, float targetAlpha)
    {
        Color color = image.color;
        float startAlpha = color.a;
        float elapsedTime = 0f;
        float duration = .5f; // Duration of the fade effect

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            color.a = alpha;
            image.color = color;
            yield return null;
        }

        color.a = targetAlpha; // Ensure final alpha is set
        image.color = color;
    }

    public void Envido()
    {
        secondFlag = true;
        polskyText.ChangeText("Real Envido!");
        lucasText.ChangeText("No nos achiquemos ahora Juan");
        firstOptions.SetActive(false);
        secondOptions.SetActive(true);
    }

    #endregion

    #region Second Options
    public void FaltaEnvido()
    {
        secondOptions.SetActive(false);
    }

    public void NoQuieroRealEnvido()
    {
        sequenceAnimator.enabled = false;
        lucasText.ChangeText("");
        polskyText.ChangeText("Sabíamos que no te daba el cuero, Juan.");

        secondOptions.SetActive(false);
        NoQuieroRealButton.interactable = false;
        string newText =
            "<s>" + NoQuieroRealButton.gameObject.GetComponent<TextMeshProUGUI>().text + "</s>";
        NoQuieroRealButton.gameObject.GetComponent<TextMeshProUGUI>().text = newText;

        Destroy(NoQuieroRealButton.GetComponent<ButtonManager>());
        Invoke("ShowOffText", 3f);
    }
    #endregion
}
