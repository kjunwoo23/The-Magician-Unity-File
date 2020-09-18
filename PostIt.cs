using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostIt : MonoBehaviour
{
    public Hacking hacking;
    public int puzzleSize;
    bool stay;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player" && PostItManager.instance.post)
        {
            stay = true;
            PostItManager.instance.SpawnPostIt(puzzleSize);
            PostItManager.instance.GetComponent<Animator>().SetBool("post", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player" && PostItManager.instance.post && !PostItManager.instance.pass)
        {
            stay = false;
            Transform[] childList = PostItManager.instance.GetComponentsInChildren<Transform>(true);
            if (childList != null)
            {
                for (int i = 0; i < childList.Length; i++)
                {
                    if (childList[i] != PostItManager.instance.transform)
                        Destroy(childList[i].gameObject);
                }
            }
            PostItManager.instance.GetComponent<Animator>().SetBool("post", false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
