using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToNext : MonoBehaviour
{
    public Hacking hacking;
    public Animator animator;
    public Text num;
    public int elvTime;
    public float y;
    bool next = false;
    bool open = false;
    public int type;
    public int bgm;
    public bool npc;
    public bool mistake;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("BgmSlider").GetComponent<Slider>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && open && (!Player.instance.isDisguise || EffectManager.instance.effectSounds[12].source.isPlaying))
        {
            collision.transform.position += new Vector3(0, y, 0);
            Player.instance.alternative = false;
            if (npc) Player.instance.noR = true;
            else Player.instance.noR = false;
            if (type == 0) hacking.enabled = false;
            if (Player.instance.deck != 52)
            {
                Player.instance.deck = 52;
                EffectManager.instance.effectSounds[30].source.Play();
            }
            EffectManager.instance.effectSounds[20].source.Stop();
            EffectManager.instance.effectSounds[21].source.Stop();
            EffectManager.instance.effectSounds[22].source.Stop();
            PostItManager.instance.pass = false;

            if (bgm != -1)
                if (SoundManager.instance.bgmPlayer.clip != SoundManager.instance.bgmSounds[bgm].clip)
                {
                    SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[bgm].clip;
                    SoundManager.instance.bgmPlayer.Play();
                }
            open = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 0)
        {
            if (hacking.hacking == hacking.maxHacking && !next)
            {
                next = true;
                if (elvTime == 0)
                {
                    open = true;
                    return;
                }
                StartCoroutine(Elevator());
            }
        }
        else if (type == 1)
        {
            open = true;
        }
    }

    IEnumerator Elevator()
    {
        if (mistake) Player.instance.deck /= 2;
        EffectManager.instance.effectSounds[8].source.Play();
        num.text = elvTime.ToString();
        animator.SetBool("elevator", true);
        yield return new WaitForSeconds(1);
        for (int i = elvTime; i >= 0; i--)
        {
            num.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        EffectManager.instance.effectSounds[29].source.Play();
        open = true;
        animator.SetBool("elevator", false);
    }
}
