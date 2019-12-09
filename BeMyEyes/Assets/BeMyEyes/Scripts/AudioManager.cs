using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource background;
    public AudioSource SFX;

    public AudioClip selectionClip;
    public AudioClip backgroundMusic1;
    public AudioClip backgroundMusic2;
    public AudioClip backgroundMusic3;
    public AudioClip errorClip;

    //private Slider musicVolume;
    //private Slider effectsVolume;

    // Start is called before the first frame update
    void Start()
    {
        //musicVolume = GameObject.Find("Music Volume").GetComponent<Slider>();
        //effectsVolume = GameObject.Find("Effects Volume").GetComponent<Slider>();
        background.loop = true;
        background.clip = backgroundMusic1;
        background.Play();
        //StartCoroutine(playSoundTrack());
    }

    public void playSelectionClip()
    {
        SFX.PlayOneShot(selectionClip);
    }
    
    public void playErrorClip()
    {
        SFX.PlayOneShot(errorClip);
    }

    public void setMusic(bool check)
    {
        background.mute = !background.mute;
    }

    public void setVolumeMusic()
    {
        //Debug.Log(musicVolume.value);
        //background.volume = musicVolume.value;
    }

    public void setEffects(bool check)
    {
        SFX.mute = !SFX.mute;
    }

    public void setVolumeEffects()
    {
        //SFX.volume = effectsVolume.value;
    }

    IEnumerator playSoundTrack()
    {
        background.clip = backgroundMusic1;
        background.Play();
        yield return new WaitForSeconds(backgroundMusic1.length);
        background.clip = backgroundMusic2;
        background.Play();
        yield return new WaitForSeconds(backgroundMusic2.length);
        background.clip = backgroundMusic3;
        background.Play();
    }

}
