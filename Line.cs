using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [System.Serializable]
    public class Dialogue
    {
        [TextArea(3, 10)]
        public string[] sentences;
        public int[] npc;
        public int[] setTrue = { 0, 0, 0 };
        public int[] setFalse = { 0, 0, 0 };
    }
    public Dialogue dialogue;

    int i = 0;
    string line;
    int npc;
    int lineStop = 0;
    int lineSize;
    bool stay = false;
    bool skip = false;
    void Start()
    {
        if (!enabled) return;
        npc = dialogue.npc[i];
        line = dialogue.sentences[i];
        lineSize = dialogue.sentences.Length;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player")
        {
            Player.instance.skill = true;
            Player.instance.animator.SetBool("walking", false);
            stay = true;
            i = 0;
            DialogueManager.instance.ShowMessage(0, line);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player")
        {
            if (stay == false)
            {
                stay = true;
                i = 0;
                DialogueManager.instance.ShowMessage(0, line);
            }
        }
    }
    void Update()
    {
        if (!enabled) return;
        if (stay)
        {/*
            if (Input.GetKeyDown(KeyCode.W) && !(DialogueManager.instance.animator.GetBool("Window")))
            {
                DialogueManager.instance.animator.SetBool("Window", true);
                EffectManager.instance.effectSounds[23].source.Play();
            }*/
            /*if (Input.GetKeyDown(KeyCode.S) && (DialogueManager.instance.animator.GetBool("Window")) && skip)
            {
                DialogueManager.instance.animator.SetBool("Window", false);
                //EffectManager.instance.effectSounds[4].source.Stop();
            }*/
            if (lineStop == 0)
            {
                npc = dialogue.npc[i];
                line = dialogue.sentences[i];
                DialogueManager.instance.WriteMessage(npc, line);
                lineStop++;
            }
            if (i == lineSize - 2)
            {
                i++;
                DialogueManager.instance.HideMessage();
                Player.instance.skill = false;
                skip = true;
            }
            if (Input.GetKeyDown(KeyCode.Space) && i < lineSize - 2)
            {
                DialogueManager.instance.Write();
                i++;
                npc = dialogue.npc[i];
                line = dialogue.sentences[i];
                DialogueManager.instance.WriteMessage(npc, line);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player")
        {
            Player.instance.skill = false;
            lineStop = 0;
            DialogueManager.instance.HideMessage();
            if (i == lineSize - 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    SwitchManager.instance.switches[dialogue.setTrue[i]].bools = true;
                    SwitchManager.instance.switches[dialogue.setFalse[i]].bools = false;
                }
            }
            stay = false;
        }
    }
}
