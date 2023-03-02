using System;
using UnityEngine;


public enum SoundType
{
    ButtonClick,
    Background,
    LevelStart,
    LevelEnd,
    FoodPickUp,
    FoodNotPicked
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
        PlayBgSound(SoundType.Background);
    }

    public void PlaySfxSound(SoundType type)
    {
        Sounds sound = Array.Find(sounds, s => s.soundType == type);
        if (sound == null)
            return;
        AudioClip clip = sound.soundClip;
        soundSfx.PlayOneShot(clip);
    }

    public void PlayBgSound(SoundType type)
    {
        Sounds sound = Array.Find(sounds, s => s.soundType == type);
        if (sound == null)
            return;
        AudioClip clip = sound.soundClip;
        soundBg.clip = clip;
        soundBg.Play();
    }

    public void PauseSound()
    {
        soundBg.Pause();
    }
    public void ResumeSound()
    {
        soundBg.Play();
    }
}
