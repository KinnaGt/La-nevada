using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEternaut : MonoBehaviour
{
    [SerializeField]
    SequenceManager sequenceManager;

    Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    public void OnMouseDown()
    {
        col.enabled = false;
        sequenceManager.NextSequence();
    }
}
