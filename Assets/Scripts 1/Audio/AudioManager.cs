using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;



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
        Play("Theme");
    }

    public void Play(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Play();
    }

    private void Update()
    {
        if (GameManager.gameIsPaused)
        {
            sounds[0].source.pitch = 0.5f;
        }
        else
        {
            sounds[0].source.pitch = 1f;
        }
    }
}
