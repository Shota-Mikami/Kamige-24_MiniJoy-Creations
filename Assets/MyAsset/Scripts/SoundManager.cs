using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] public List<AudioClip> SE;
    [SerializeField] public List<AudioClip> BGM;

    private AudioSource[] BGM_Sources = new AudioSource[2];
    private AudioSource[] SE_Sources = new AudioSource[16];




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // BGM—p AudioSource’Ç‰Á
        BGM_Sources[0] = gameObject.AddComponent<AudioSource>();
        BGM_Sources[1] = gameObject.AddComponent<AudioSource>();

        // SE—p AudioSource’Ç‰Á
        for (int i = 0; i < SE_Sources.Length; i++)
        {
            SE_Sources[i] = gameObject.AddComponent<AudioSource>();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBGM(int BGMnum, bool loop)
    {
        BGM_Sources[0].loop = loop;
        BGM_Sources[0].clip = BGM[BGMnum];
    }

    public void PlaySE(int SEnum)
    {
        foreach (AudioSource source in SE_Sources)
        {
            if (source.isPlaying)
                continue;
            source.clip = SE[SEnum];
            source.Play();
            break;
        }
    }

    public void StopBGM()
    {
        BGM_Sources[0].Stop();
        BGM_Sources[1].Stop();
        BGM_Sources[0].clip = null;
        BGM_Sources[1].clip = null;
    }

    public void StopSE()
    {
        foreach (AudioSource source in SE_Sources)
        {
            source.Stop();
            source.clip = null;
        }
    }
}

