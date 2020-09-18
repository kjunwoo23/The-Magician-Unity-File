using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager2 : MonoBehaviour
{/*
    float startLibrary;
    public GameObject player1;
    public dqwd dqwd;
    public SoundManager soundManager;
    public EffectManager effectManager;
    public float currentLibrary;
    public static LoadManager2 instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startLibrary = PlayerPrefs.GetFloat("StartLibrary");
        currentLibrary = startLibrary;
        MapManager.instance.mapUpdate();

        if (startLibrary == 0)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[0].clip;
            soundManager.bgmPlayer.Play();
        }
        if (startLibrary == 1)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[1].clip;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[14].clip;
            player1.transform.position = new Vector3(-206.59f, -58.7f,0);
        }
        if (startLibrary == 1.5)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[2].clip;
            soundManager.bgmPlayer.Play();
            player1.transform.position = new Vector3(-159.87f, 1.98f, 0);
        }
        if (startLibrary == 2)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[1].clip;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[14].clip;
            player1.transform.position = new Vector3(147.4f, -57.4f, 0);
        }
        if (startLibrary == 2.5)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[9].clip;
            soundManager.bgmPlayer.Play();
            player1.transform.position = new Vector3(185.6f, -0.6f, 0);
            dqwd.knife = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 3)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[1].clip;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[14].clip;
            player1.transform.position = new Vector3(457.9f, -59.1f, 0);
            dqwd.knife = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 3.5)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[7].clip;
            soundManager.bgmPlayer.Play();
            player1.transform.position = new Vector3(479.24f, -0.62f, 0);
            dqwd.knife = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 4)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[1].clip;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[14].clip;
            player1.transform.position = new Vector3(793.72f, -59.12f, 0);
            dqwd.knife = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 4.5)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[10].clip;
            soundManager.bgmPlayer.Play();
            player1.transform.position = new Vector3(817.6f, -0.57f, 0);
            dqwd.knife = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 5)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[1].clip;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[14].clip;
            player1.transform.position = new Vector3(1054.9f, -59f, 0);
            dqwd.knife = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 5.5)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[10].clip;
            soundManager.bgmPlayer.Play();
            player1.transform.position = new Vector3(1088.5f, -0.57f, 0);
            dqwd.knife = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 6)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[3].clip;
            soundManager.bgmPlayer.volume = 0.5f;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[14].clip;
            player1.transform.position = new Vector3(1455.6f, -58.9f, 0);
            dqwd.knife = true;
            GameObject.Find("SwitchManager").GetComponent<SwitchManager>().switches[15].bools = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 6.5)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[11].clip;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[16].clip;
            player1.transform.position = new Vector3(1486, -0.57f, 0);
            dqwd.knife = true;
            GameObject.Find("SwitchManager").GetComponent<SwitchManager>().switches[16].bools = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 7)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[9].clip;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[14].clip;
            player1.transform.position = new Vector3(1748, -58.4f, 0);
            dqwd.knife = true;
            GameObject.Find("SwitchManager").GetComponent<SwitchManager>().switches[16].bools = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 7.5)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[12].clip;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[16].clip;
            player1.transform.position = new Vector3(1760, -0.57f, 0);
            dqwd.knife = true;
            GameObject.Find("SwitchManager").GetComponent<SwitchManager>().switches[16].bools = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 8)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[9].clip;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[14].clip;
            player1.transform.position = new Vector3(2035, -58.4f, 0);
            dqwd.knife = true;
            GameObject.Find("SwitchManager").GetComponent<SwitchManager>().switches[16].bools = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 8.5)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[8].clip;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[16].clip;
            player1.transform.position = new Vector3(2047, -0.57f, 0);
            dqwd.knife = true;
            GameObject.Find("SwitchManager").GetComponent<SwitchManager>().switches[16].bools = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 9)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[8].clip;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[16].clip;
            player1.transform.position = new Vector3(2277.75f, -0.57f, 0);
            dqwd.knife = true;
            GameObject.Find("SwitchManager").GetComponent<SwitchManager>().switches[16].bools = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 9.5)
        {
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[8].clip;
            soundManager.bgmPlayer.Play();
            effectManager.effectSounds[11].clip = effectManager.effectSounds[16].clip;
            player1.transform.position = new Vector3(2349f, 60.4f, 0);
            dqwd.knife = true;
            GameObject.Find("SwitchManager").GetComponent<SwitchManager>().switches[16].bools = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }
        if (startLibrary == 10)
        {
            //dqwd.playerSpeed = 15;
            soundManager.bgmPlayer.clip = soundManager.bgmSounds[8].clip;
            soundManager.bgmPlayer.Play();
            player1.transform.position = new Vector3(1098f, 61.83f, 0);
            dqwd.knife = true;
            GameObject.Find("SwitchManager").GetComponent<SwitchManager>().switches[16].bools = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
        }



    }*/
}
