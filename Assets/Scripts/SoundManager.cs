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
            //Destroy(gameOver);
        }
        else
        {
            instance = this;
        }
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
