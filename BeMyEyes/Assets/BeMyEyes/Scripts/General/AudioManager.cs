using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{
    private int _track;
    private int _lastTrack;

    public AudioSource background;
    public AudioSource SFX;

    public AudioClip selectionClip;
    public AudioClip backgroundMusic1;
    public AudioClip backgroundMusic2;
    public AudioClip backgroundMusic3;
    public AudioClip errorClip;

    private Slider musicVolume;
    private Slider effectsVolume;

    // Start is called before the first frame update
    void Start()
    {
        musicVolume = GameObject.Find("Music Volume").GetComponent<Slider>();
        effectsVolume = GameObject.Find("Effects Volume").GetComponent<Slider>();
    }

    private void Update()
    {
        if (!background.isPlaying)
        {
            _track = Random.Range((int)0, (int)3);
            if (_track == 0)
            {
                if(_track != _lastTrack)
                {
                    background.PlayOneShot(backgroundMusic1);
                    _lastTrack = _track;
                }
            }
            else if (_track == 1)
            {
                if(_track != _lastTrack)
                {
                    background.PlayOneShot(backgroundMusic2);
                    _lastTrack = _track;
                }
            }
            else if (_track == 2)
            {
                if(_track != _lastTrack)
                {
                    background.PlayOneShot(backgroundMusic3);
                    _lastTrack = _track;
                }
            }
        }
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
        background.volume = musicVolume.value;
    }

    public void setEffects(bool check)
    {
        SFX.mute = !SFX.mute;
    }

    public void setVolumeEffects()
    {
        SFX.volume = effectsVolume.value;
    }

}
