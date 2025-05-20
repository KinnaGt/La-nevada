using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor = Color.yellow;
    public float scaleAmount = 1.1f;
    public float scaleSpeed = 10f;
    public float colorSpeed = 10f;

    private Vector3 originalScale;
    private Vector3 targetScale;
    private Color originalColor;
    private Color targetColor;

    private TextMeshProUGUI tmp;

    void Start()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        originalScale = tmp.transform.localScale;
        targetScale = originalScale;
        originalColor = tmp.color;
        targetColor = originalColor;
    }

    void Update()
    {
        tmp.transform.localScale = Vector3.Lerp(
            tmp.transform.localScale,
            targetScale,
            Time.deltaTime * scaleSpeed
        );
        tmp.color = Color.Lerp(tmp.color, targetColor, Time.deltaTime * colorSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = originalScale * scaleAmount;
        targetColor = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = originalScale;
        targetColor = originalColor;
    }
}
