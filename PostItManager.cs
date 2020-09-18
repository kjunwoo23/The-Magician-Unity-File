using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostItManager : MonoBehaviour
{
    [System.Serializable]
    public class Memo
    {
        [TextArea(3, 10)]
        public string[] sentences;
    }
    public Memo memo;
    public GameObject[] posts;
    public static PostItManager instance;
    public bool pass = false;
    public bool post = false;
    public Animator consolAnimator;
    public Text consol;
    public Text access;
    string ans;

    private void Start()
    {
        instance = this;
    }
    public void SpawnPostIt(int puzzleSize)
    {
        EffectManager.instance.effectSounds[24].source.Play();
        for (int i = 0; i < puzzleSize; i++)
        {
            GameObject child = Instantiate(posts[Random.Range(0, 4)], new Vector3(Random.Range(-200, 201), Random.Range(-200, 201), 0), Quaternion.Euler(0, 0, Random.Range(-45, 46))) as GameObject;
            child.transform.parent = transform;
            child.transform.position += transform.position;
            Text text = child.GetComponentInChildren<Text>();
            if (i == 0)
            {
                ans = Random.Range(0, 99999999).ToString("00000000");
                text.text = "PW : " + ans;
                child.GetComponent<Posts>().pw = true;
            }
            else
            {
                text.fontSize = 20;
                text.text = memo.sentences[Random.Range(0, memo.sentences.Length)];
            }
        }
    }
    public IEnumerator Typing()
    {
        consol.text = "";
        access.text = "";
        consolAnimator.SetBool("consol", true);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < ans.Length; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.05f, 0.50f));
            EffectManager.instance.effectSounds[26].source.Play();
            consol.text += ans[i];
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            access.text += ". ";
        }
        yield return new WaitForSeconds(1.5f);
        EffectManager.instance.effectSounds[27].source.Play();
        access.text += "ACCESS ALLOWED";
        pass = true;
        yield return new WaitForSeconds(2f);
        consolAnimator.SetBool("consol", false);

    }
}
