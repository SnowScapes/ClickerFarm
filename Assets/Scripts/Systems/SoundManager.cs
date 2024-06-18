using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip ClickSound;
    [SerializeField] private AudioSource ClickSource;

    private void Start()
    {
        GameManager.Instance.Crop.ClickEvent += PlayClickSound;
    }

    private void PlayClickSound(float _)
    {
        ClickSource.PlayOneShot(ClickSound);
    }
}
