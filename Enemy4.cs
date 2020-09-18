using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy4 : MonoBehaviour
{
    public float slowSpeed;
    public float fastSpeed;
    public float confSpeed;
    public float maxTime;
    public float curTime;
    public Animator animator;
    bool flag = false;
    public Transform target;
    public Dummy dummy;
    public bool area;
    Vector2 MousePosition;
    public Text text;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.transform.position.y > transform.position.y + 5 || Player.instance.transform.position.y < transform.position.y - 5) return;
        curTime += Time.deltaTime / Player.instance.BWJoker;

        if (Player.instance.guideOn == true)
        {
            if (canvas.enabled == false)
                canvas.enabled = true;
        }
        else if (canvas.enabled == true)
            canvas.enabled = false;

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
            {
                target.position = dummy.transform.position;
                if (dummy.transform.localScale.x > 0)
                    if (target.transform.position.x < transform.position.x)
                        curTime = 0;
                if (dummy.transform.localScale.x < 0)
                    if (target.transform.position.x > transform.position.x)
                        curTime = 0;
                if (curTime > maxTime)
                {
                    animator.SetBool("back", false);
                    text.enabled = true;
                    if (transform.position.x < target.position.x)
                    {
                        transform.localScale = new Vector3(-0.9f, 0.9f, 0);
                        transform.position += new Vector3(fastSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                    }
                    if (transform.position.x > target.position.x)
                    {
                        transform.localScale = new Vector3(0.9f, 0.9f, 0);
                        transform.position -= new Vector3(fastSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                    }
                }
                else
                {
                    animator.SetBool("back", true);
                    text.enabled = false;
                    if (transform.position.x < target.position.x)
                    {
                        transform.localScale = new Vector3(-0.9f, 0.9f, 0);
                        if (!area)
                            transform.position -= new Vector3(slowSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                        else
                            transform.position += new Vector3(slowSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);

                    }
                    if (transform.position.x > target.position.x)
                    {
                        transform.localScale = new Vector3(0.9f, 0.9f, 0);
                        if (!area)
                            transform.position += new Vector3(slowSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                        else
                            transform.position -= new Vector3(slowSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                    }
                }
            }
            else
            {
                target.position = Player.instance.transform.position;
                MousePosition = Player.instance.MousePosition;
                if (Player.instance.isHacking) ;
                else if (MousePosition.x > Player.instance.transform.position.x + 0.5 * Player.instance.playerSize)
                {
                    if (Player.instance.transform.position.x < transform.position.x)
                        curTime = 0;
                }
                else if (MousePosition.x < Player.instance.transform.position.x - 0.5 * Player.instance.playerSize)
                {
                    if (Player.instance.transform.position.x > transform.position.x)
                        curTime = 0;
                }
                if (curTime > maxTime)
                {
                    animator.SetBool("back", false);
                    text.enabled = true;
                    if (transform.position.x < target.position.x)
                    {
                        transform.localScale = new Vector3(-0.9f, 0.9f, 0);
                        transform.position += new Vector3(fastSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                    }
                    if (transform.position.x > target.position.x)
                    {
                        transform.localScale = new Vector3(0.9f, 0.9f, 0);
                        transform.position -= new Vector3(fastSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                    }
                }
                else
                {
                    animator.SetBool("back", true);
                    text.enabled = false;
                    if (transform.position.x < target.position.x)
                    {
                        transform.localScale = new Vector3(-0.9f, 0.9f, 0);
                        if (!area)
                            transform.position -= new Vector3(slowSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                        else
                            transform.position += new Vector3(slowSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);

                    }
                    if (transform.position.x > target.position.x)
                    {
                        transform.localScale = new Vector3(0.9f, 0.9f, 0);
                        if (!area)
                            transform.position += new Vector3(slowSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                        else
                            transform.position -= new Vector3(slowSpeed * Time.deltaTime / Player.instance.BWJoker, 0, 0);
                    }
                }
            }
        }
        area = false;
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
