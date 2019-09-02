using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip cursor;
    public AudioClip drop;
    public AudioClip control;
    public AudioClip lineClear;

    private Ctrl ctrl;
    private AudioSource audioSource;
    private bool isMute = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ctrl = GetComponent<Ctrl>();
    }

    public void PlayCursor()
    {
        AudioPlay(cursor);

    }

    public void PlayDrop()
    {
        AudioPlay(drop);
    }
    public void PlayControl()
    {
        AudioPlay(control);
    }
    public void PlayLineClear()
    {
        AudioPlay(lineClear);
    }

    private void AudioPlay(AudioClip clip)
    {
        if (isMute) return;
        audioSource.clip = clip;
        audioSource.Play(); 
    }

    public  void OnAudioButtonClick()
    {
        isMute = !isMute;
        ctrl.view.SetMuteActice(isMute);
        if(isMute == false)
        {
            PlayCursor();
        }
    }
}
