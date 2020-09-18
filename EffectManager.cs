using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Effect
{
    public string soundName;
    public AudioClip clip;
    public AudioSource source;
}
public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;

    [Header("효과음 등록")]
    [SerializeField]
    public Effect[] effectSounds;

    void Start()
    {
        instance = this;
        //bgm이랑 bgs랑 다름!!!

        if (effectSounds.Length == 5)
        {
            for (int i = 0; i < effectSounds.Length; i++)
            {
                effectSounds[i].source = gameObject.AddComponent<AudioSource>();
                effectSounds[i].source.clip = effectSounds[i].clip;
                effectSounds[i].source.loop = false;
            }
            return;
        }


        for (int i = 0; i < effectSounds.Length; i++)
        {
            effectSounds[i].source = gameObject.AddComponent<AudioSource>();
            effectSounds[i].source.clip = effectSounds[i].clip;
            effectSounds[i].source.loop = false;
            if (i == 1 || i == 2 || i == 40 || i == 41)
                effectSounds[i].source.volume *= 0.5f;
            if (i == 20 || i == 22)
                effectSounds[i].source.volume *= 0.3f;
            if (i == 21)
                effectSounds[i].source.volume *= 0.1f;
            if (i == 6 || i == 7 || i == 12 || i == 14 || i == 20 || i == 21 || i == 22)
                effectSounds[i].source.loop = true;
        }
    }
    
    public void SetEffectVolume(Slider slider)
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            effectSounds[i].source.volume = slider.value;
            if (i == 1 || i == 2 || i == 40 || i == 41)
                effectSounds[i].source.volume *= 0.5f;
            if (i == 20 || i == 22)
                effectSounds[i].source.volume *= 0.3f;
            if (i == 21)
                effectSounds[i].source.volume *= 0.1f;
        }
    }
}
