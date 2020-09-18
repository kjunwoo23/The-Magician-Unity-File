using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    public int hp;
    int fullHp;
    public bool dmg;
    public float slowSpeed;
    public float fastSpeed;
    public float confSpeed;
    public Animator animator;
    bool flag = false;
    public Transform target;
    public Dummy dummy;
    public float restTime;
    public float dmgTime;
    public RawImage rawImage;
    public Image image;
    public Text text;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        fullHp = hp;
    }

    // Update is called once per frame
    void Update()
    {

        if (Player.instance.transform.position.y > transform.position.y + 5 || Player.instance.transform.position.y < transform.position.y - 5) return;

        if (Player.instance.guideOn == true)
        {
            if (canvas.enabled == false)
                canvas.enabled = true;
        }
        else if (canvas.enabled == true)
            canvas.enabled = false;

        text.text = hp.ToString();
        if (hp <= 0) text.enabled = false;
        else text.enabled = true;

        if (Player.instance.alternative && Player.instance.isDisguise && flag == false)
        {
            StartCoroutine("Confusion");
            animator.SetBool("panic", true);
        }
        else if (Player.instance.alternative && !Player.instance.isDisguise)
        {
            StopCoroutine("Confusion");
            animator.SetBool("panic", false);
        }

        if (!animator.GetBool("panic") && dmg)
        {
            if (dummy.enabled == true)
                target.position = dummy.transform.position;
            else
                target.position = Player.instance.transform.position;
            if (hp > 0)
            {
                if (transform.position.x < target.position.x)
                {
                    transform.localScale = new Vector3(-0.9f, 0.9f, 0);
                    transform.position += new Vector3(fastSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                    text.transform.localScale = new Vector3(-0.01f, 0.01f, 0);
                }
                if (transform.position.x > target.position.x)
                {
                    transform.localScale = new Vector3(0.9f, 0.9f, 0);
                    transform.position -= new Vector3(fastSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                    text.transform.localScale = new Vector3(0.01f, 0.01f, 0);
                }
            }
            else
                StartCoroutine(Rest());
        }
    }
    IEnumerator Rest()
    {
        rawImage.enabled = true;
        image.enabled = true;
        animator.SetBool("back", true);
        dmgTime = restTime;
        dmg = false;
        for (; dmgTime > 0; dmgTime -= Time.deltaTime / Player.instance.BWJoker)
        {
            image.fillAmount = (restTime - dmgTime) / restTime;
            yield return null;
        }
        hp = fullHp;
        dmg = true;
        animator.SetBool("back", false);
        rawImage.enabled = false;
        image.enabled = false;
    }


    IEnumerator Confusion()
    {
        flag = true;
        while (true)
        {
            yield return new WaitForSeconds(0.02f);
            transform.position -= new Vector3(confSpeed * 3 * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(0.02f);
            transform.position += new Vector3(confSpeed * 3 * Time.deltaTime, 0, 0);
        }
    }
}
