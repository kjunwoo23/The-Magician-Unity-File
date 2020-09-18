using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hacking : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public bool onTrigger = false;
    public float hacking;
    public float maxHacking;
    public float postPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onTrigger = false;
        }
    }

  

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > Player.instance.transform.position.y + 5 || transform.position.y < Player.instance.transform.position.y - 5) return;

        if (onTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.instance.animator.SetBool("walking", false);
                Player.instance.animator.SetBool("hacking", true);
                Player.instance.isHacking = true;
                Player.instance.skill = true;
                Player.instance.myRigid.constraints = RigidbodyConstraints2D.FreezePosition|RigidbodyConstraints2D.FreezeRotation;
                EffectManager.instance.effectSounds[6].source.Play();
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                Player.instance.animator.SetBool("hacking", false);
                Player.instance.isHacking = false;
                Player.instance.skill = false;
                Player.instance.myRigid.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                EffectManager.instance.effectSounds[6].source.Pause();
            }
        }
        else if (Player.instance.isHacking || Player.instance.animator.GetBool("hacking"))
        {
            Player.instance.animator.SetBool("hacking", false);
            Player.instance.isHacking = false;
            Player.instance.skill = false;
            Player.instance.myRigid.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            EffectManager.instance.effectSounds[6].source.Pause();
        }
        if (Player.instance.isHacking == true)
        {
            if (Player.instance.animator.GetBool("disguise") && !Player.instance.fade.enabled)
            {
                Player.instance.StopCoroutine("Disguise");
                Player.instance.animator.SetBool("disguise", false);
                Player.instance.disguiseCur = Player.instance.disguiseCool;
                Player.instance.alpha = Player.instance.sprite.color;
                Player.instance.alpha.a = 1;
                Player.instance.sprite.color = Player.instance.alpha;
                Player.instance.isDisguise = false;
                EffectManager.instance.effectSounds[12].source.Stop();
                Dummy.instance.DestroyDummy();
            }
            if (hacking >= maxHacking)
                hacking = maxHacking;
            else if (hacking < postPoint * maxHacking || PostItManager.instance.pass)
            {
                if (!PostItManager.instance.post)
                    hacking += Time.deltaTime;
            }
            else if ((hacking >= postPoint * maxHacking || !PostItManager.instance.pass) && !PostItManager.instance.consolAnimator.GetBool("consol"))
            {
                PostItManager.instance.post = true;
                hacking = (int)(maxHacking * postPoint);
            }

        }
        if (hacking > 0 && !EffectManager.instance.effectSounds[20].source.isPlaying)
            EffectManager.instance.effectSounds[20].source.Play();
        /*
        if (hacking >= 0.5f * maxHacking && !EffectManager.instance.effectSounds[21].source.isPlaying)
        {
            EffectManager.instance.effectSounds[21].source.Play();
            EffectManager.instance.effectSounds[20].source.Stop();
        }
        */
        if (hacking == maxHacking && !EffectManager.instance.effectSounds[22].source.isPlaying)
        {
            EffectManager.instance.effectSounds[22].source.Play();
            EffectManager.instance.effectSounds[20].source.Stop();
        }
        if (text.text != 100 * hacking / maxHacking + "%")
            text.text = 100 * hacking / maxHacking + "%";
        slider.value = hacking / maxHacking;
    }
}
