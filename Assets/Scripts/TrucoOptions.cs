using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrucoOptions : MonoBehaviour
{
    [SerializeField]
    TypewritingSequences lucasText;

    [SerializeField]
    GameObject firstOptions;

    [SerializeField]
    Button trucoButton;

    public void Truco()
    {
        lucasText.ChangeText("Pero... ¿Vos sos boludo Juan? No se puede cantar truco en un envido");
        firstOptions.SetActive(false);
        trucoButton.interactable = false;
        string newText =
            "<s>" + trucoButton.gameObject.GetComponent<TextMeshProUGUI>().text + "</s>";
        trucoButton.gameObject.GetComponent<TextMeshProUGUI>().text = newText;
        Destroy(trucoButton.GetComponent<ButtonHoverEffect>());
        Invoke("ShowEnvidoOptions", 5f);
    }

    void ShowEnvidoOptions()
    {
        lucasText.ChangeText("Cantá vos que ando flojo.");
        firstOptions.SetActive(true);
    }

    public void Envido() { }

    public void NoQuiero() { }
}
