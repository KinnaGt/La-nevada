using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    Image image;

    [SerializeField]
    float fadeDuration = 1f;

    [SerializeField]
    float alphaTarget = .15f;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        Color color = image.color;
        float startAlpha = color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, alphaTarget, time / fadeDuration);
            image.color = color;
            yield return null;
        }
        color.a = alphaTarget;
        image.color = color;
    }

    #region Button Methods
    public void StartButton()
    {
        SfxManager.Instance.PlayClick();
        //Change to game scene
        SceneManager.LoadScene("Game");
    }

    public void OptionsButton()
    {
        SfxManager.Instance.PlayClick();
    }

    public void ExitButton()
    {
        SfxManager.Instance.PlayClick();
        Application.Quit();
    }
    #endregion
}
