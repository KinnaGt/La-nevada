using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextContainer : MonoBehaviour
{
    [SerializeField]
    GameObject trucoFirstOptions;

    public void ShowTrucoOptions()
    {
        trucoFirstOptions.SetActive(true);
    }

    public void HideTexts(int id)
    {
        string idStr = id.ToString();
        foreach (Transform child in transform)
        {
            if (child.name.StartsWith(idStr))
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void ShowText(int id)
    {
        string idStr = id.ToString();
        foreach (Transform child in transform)
        {
            if (child.name.StartsWith(idStr))
            {
                child.gameObject.SetActive(true);
                break;
            }
        }
    }
}
