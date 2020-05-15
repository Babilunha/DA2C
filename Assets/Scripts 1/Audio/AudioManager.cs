using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    private bool backgroundMaxBool;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {

        Play("backgroundMax");
        backgroundMaxBool = true;
    }

    public void Play(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Play();

    }

    private void Update()
    {
        if (MyGameManager.gameIsPaused)
        {
            getSound("backgroundMax").source.pitch = 0.5f;
            getSound("backgroundLera").source.pitch = 0.5f;
        }
        else
        {
            getSound("backgroundMax").source.pitch = 1f;
            getSound("backgroundLera").source.pitch = 1f;
        }

        changeMusic();

        
    }

    public Sound getSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s;
    }

    public void stopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void changeMusic()
    {
        if (Input.GetKeyDown(KeyCode.M) && backgroundMaxBool != true)
        {
            stopSound("backgroundLera");
            Play("backgroundMax");
            backgroundMaxBool = true;
        } else if (Input.GetKeyDown(KeyCode.M) && backgroundMaxBool == true)
        {
            stopSound("backgroundMax");
            Play("backgroundLera");
            backgroundMaxBool = false;
        }


    }
}
