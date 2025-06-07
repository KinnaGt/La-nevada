using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager
    : MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler,
        ISelectHandler,
        IDeselectHandler
{
    [DllImport("__Internal")]
    private static extern void Speak(string message);

    public Color hoverColor = Color.yellow;
    public float scaleAmount = 1.1f;
    public float scaleSpeed = 10f;
    public float colorSpeed = 10f;

    [SerializeField]
    public bool isDefaultSelected = false;

    [Header("Accessibility")]
    [Tooltip("Texto leído por lectores de pantalla")]
    public string accessibilityLabel;

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

        if (isDefaultSelected)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }

    void Update()
    {
        SelectDefaultButton();
        tmp.transform.localScale = Vector3.Lerp(
            tmp.transform.localScale,
            targetScale,
            Time.deltaTime * scaleSpeed
        );
        tmp.color = Color.Lerp(tmp.color, targetColor, Time.deltaTime * colorSpeed);
    }

    private void SelectDefaultButton()
    {
        if (isDefaultSelected && EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetHoverState(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetHoverState(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        SpeakIfPossible();
        SetHoverState(true); // Cuando se selecciona por teclado
    }

    public void OnDeselect(BaseEventData eventData)
    {
        SetHoverState(false); // Cuando pierde el foco
    }

    private void SetHoverState(bool isHovering)
    {
        targetScale = isHovering ? originalScale * scaleAmount : originalScale;
        targetColor = isHovering ? hoverColor : originalColor;
    }

    private void SpeakIfPossible()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (!string.IsNullOrEmpty(accessibilityLabel))
            Speak(accessibilityLabel);
#endif
    }
}
