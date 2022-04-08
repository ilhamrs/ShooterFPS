using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip uiButton;
    public AudioClip shootWeapon;
    public AudioClip itemAudio;

    private AudioSource audio;

    private void Awake()
    {
        if (instance != null)
        {
            
        }
        else
        {
            instance = this;
        }
        audio = GetComponent<AudioSource>();
    }

    public void UIClickSfx()
    {
        audio.PlayOneShot(uiButton);
    }

    public void shootSound()
    {
        audio.PlayOneShot(shootWeapon);
    }

    public void getItemSound()
    {
        audio.PlayOneShot(itemAudio);
    }
}
