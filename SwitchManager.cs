using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

[System.Serializable]
public class Switch
{
    public string switchName;
    public bool bools;
}
public class SwitchManager : MonoBehaviour
{
    public static SwitchManager instance;

    [Header("스위치 등록")]
    [SerializeField]
    public Switch[] switches;
    public CinemachineVirtualCamera cm;
    public Player player;

    public int A, B;
    public RawImage[] twoSideCards;
    public bool clicked;

    private void Start()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (switches[1].bools == true)
        {
            if (SoundManager.instance.bgmPlayer.clip != SoundManager.instance.bgmSounds[1].clip)
            {
                SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[1].clip;
                SoundManager.instance.bgmPlayer.Play();
            }
            switches[1].bools = false;
        }
        if (switches[2].bools == true)
        {
            Player.instance.transform.position += new Vector3(0, 10, 0);
            switches[2].bools = false;
        }
    }

    public void ShowCardA(int A)
    {
        //twoSideCards[A].GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, twoSideCards[A].GetComponent<Transform>().rotation.z * 360);
        twoSideCards[A].GetComponent<RawImage>().enabled = true;
        twoSideCards[A].GetComponent<Button>().enabled = true;

    }

    public void OnClick()
    {
        StartCoroutine(ChangeCardAtoB());
    }

    public IEnumerator ChangeCardAtoB()
    {
        twoSideCards[A].GetComponent<Button>().enabled = false;
        EffectManager.instance.effectSounds[25].source.Play();
        twoSideCards[A].GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        while (twoSideCards[A].GetComponent<Transform>().rotation.y <= 0.5)
        {
            twoSideCards[A].GetComponent<Transform>().Rotate(0, 720 * Time.deltaTime, 0);
            yield return null;
        }
        twoSideCards[A].enabled = false;
        twoSideCards[B].GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0);
        twoSideCards[B].GetComponent<Button>().enabled = false;
        twoSideCards[B].enabled = true;

        while (twoSideCards[B].GetComponent<Transform>().rotation.y >= 0)
        {
            twoSideCards[B].GetComponent<Transform>().Rotate(0, -720 * Time.deltaTime, 0);
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);
        if (B == 0) EffectManager.instance.effectSounds[37].source.Play();
        else if (B == 1) EffectManager.instance.effectSounds[36].source.Play();
        yield return new WaitForSeconds(2.3f);
        //twoSideCards[B].GetComponent<Button>().enabled = true;
        clicked = true;
    }

}