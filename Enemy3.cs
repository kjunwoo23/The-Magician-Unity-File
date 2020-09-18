using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy3 : MonoBehaviour
{
    public float slowSpeed;
    public float confSpeed;
    public float dashSpeed;
    public float curTime;
    public float loopTime;
    public bool dmg;
    public Animator animator;
    bool flag = false;
    public Transform target;
    public Dummy dummy;
    public bool area = false;
    public Image ready1, ready2;
    public RawImage patterns;
    public RawImage[] cards;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.transform.position.y > transform.position.y + 5 || Player.instance.transform.position.y < transform.position.y - 5) return;
        if (!dmg) return;
        curTime += Time.deltaTime / Player.instance.BWJoker;

        if (Player.instance.guideOn == true)
        {
            if (canvas.enabled == false)
                canvas.enabled = true;
        }
        else if (canvas.enabled == true)
            canvas.enabled = false;

        ready2.fillAmount = curTime / loopTime;

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

        if (!animator.GetBool("panic"))
        {
            if (dummy.enabled == true)
                target.position = dummy.transform.position;
            else
                target.position = Player.instance.transform.position;
            if (curTime < loopTime)
            {
                animator.SetBool("back", true);
                if (transform.position.x < target.position.x)
                {
                    transform.localScale = new Vector3(-0.9f, 0.9f, 0);
                    ready1.transform.localScale = new Vector3(-0.01f, 0.01f, 0);
                    ready2.transform.localScale = new Vector3(-0.01f, 0.01f, 0);
                    patterns.transform.localScale = new Vector3(-0.01f, 0.01f, 0);
                    transform.position -= new Vector3(slowSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                }
                if (transform.position.x > target.position.x)
                {
                    transform.localScale = new Vector3(0.9f, 0.9f, 0);
                    ready1.transform.localScale = new Vector3(0.01f, 0.01f, 0);
                    ready2.transform.localScale = new Vector3(0.01f, 0.01f, 0);
                    patterns.transform.localScale = new Vector3(0.01f, 0.01f, 0);
                    transform.position += new Vector3(slowSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                }
            }
            else
            {
                dmg = false;
                StartCoroutine(Dash());
            }
        }

    }
    IEnumerator Dash()
    {
        ready1.enabled = false;
        ready2.enabled = false;
        patterns.enabled = true;
        patterns.texture = cards[0].texture;
        if (transform.position.x < target.position.x)
            for (int i = 0; i < 3; i++)
            {

                yield return new WaitForSeconds(0.5f);
                patterns.texture = cards[i + 1].texture;
                animator.SetBool("back", false);
                transform.localScale = new Vector3(-0.9f, 0.9f, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector3(dashSpeed, 0, 0);
            }
        else if (transform.position.x > target.position.x)
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.5f);
                patterns.texture = cards[i + 1].texture;
                animator.SetBool("back", false);
                transform.localScale = new Vector3(0.9f, 0.9f, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector3(-dashSpeed, 0, 0);
            }
        yield return new WaitForSeconds(0.5f);
        patterns.enabled = false;
        ready1.enabled = true;
        ready2.enabled = true;
        curTime = 0;
        dmg = true;
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
