using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance { get; private set; }

    [SerializeField]
    private AudioSource sfxSource;

    [SerializeField]
    private AudioClip[] sfxClips;

    private bool isSfxEnabled = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySfx(int index)
    {
        if (isSfxEnabled && index >= 0 && index < sfxClips.Length)
        {
            sfxSource.clip = sfxClips[index];
            sfxSource.Play();
        }
    }
}
