using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundType
{
    ButtonClick,
    Lobby,
    LevelStart,
    LevelEnd
}
[Serializable]
public class Sounds
{
    public SoundType soundType;
    public AudioClip soundClip;
}
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    [SerializeField]
    private Sounds[] sounds;

    [SerializeField]
    private AudioSource soundSfx;


    [SerializeField]
    private AudioSource soundBg;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySfxSound(SoundType type)
    {
        Sounds sound = Array.Find(sounds, s => s.soundType == type);
        AudioClip clip = sound.soundClip;
        soundSfx.PlayOneShot(clip);
    }

    public void PlayBgSound(SoundType type)
    {
        Sounds sound = Array.Find(sounds, s => s.soundType == type);
        AudioClip clip = sound.soundClip;
        soundBg.clip = clip;
        soundBg.Play();
    }
}
