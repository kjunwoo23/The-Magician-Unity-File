using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [Header("사운드 등록")]
    [SerializeField]
    public Sound[] bgmSounds;
    [Header("브금 플레이어")]
    [SerializeField]
    public AudioSource bgmPlayer;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //bgmPlayer.clip = bgmSounds[1].clip;
        //bgmPlayer.Play();
    }
    public void SetBgmVolume(Slider slider)
    {
        bgmPlayer.volume = slider.value;
        //if (bgmPlayer.clip == bgmSounds[3].clip)
            //bgmPlayer.volume = slider.value * 0.5f;
    }
}


