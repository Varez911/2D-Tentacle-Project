using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Audio[] audios;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Audio a in audios)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;

            a.source.volume = a.volume;
            a.source.pitch = a.pitch;
            a.source.loop = a.loop;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Play("BGSound");
    }

    public void Play(string musicName)
    {
        Audio a = Array.Find(audios, audio => audio.name == musicName);
        if(a == null)
        {
            return;
        }
        a.source.Play();
    }
}
