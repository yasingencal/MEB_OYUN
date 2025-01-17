using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicSound, sfxSound;
    public AudioSource musicSource,sfxSource;

    private void OnEnable()
    {
        EventManager.OnCorrectAnswer += EventManager_OnCorrectAnswer;
        EventManager.OnWrongAnswer += EventManager_OnWrongAnswer;
    }

    private void EventManager_OnWrongAnswer()
    {
        PlaySFX("Wrong");
    }

    private void EventManager_OnCorrectAnswer()
    {
        PlaySFX("Correct");
    }

    private void OnDisable()
    {
        EventManager.OnCorrectAnswer -= EventManager_OnCorrectAnswer;
        EventManager.OnWrongAnswer -= EventManager_OnWrongAnswer;
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //PlayMusic("Theme");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSound, x => x.name == name);
        
        if (s == null)
        {
            
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Ses Bulunamadý");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
