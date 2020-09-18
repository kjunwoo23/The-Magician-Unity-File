using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Faces
{
    public RawImage face;
}

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Animator animator;
    public RawImage rawImage;
    public Faces[] faces;
    public Text text;

    void Start()
    {
        instance = this;

    }
    public void Write()
    {
        if (!enabled)
            return;
        //EffectManager.instance.effectSounds[4].source.Play();
    }

    public void ShowMessage(int npc, string line)
    {
        if (!enabled)
            return;
        if (!(animator.GetBool("Window")))
        {
            EffectManager.instance.effectSounds[23].source.Play();
        }
        rawImage.texture = faces[npc].face.texture;
        animator.SetBool("Window", true);
        text.text = line;
    }


    public void WriteMessage(int npc, string line)
    {
        if (!enabled)
            return;
        rawImage.texture = faces[npc].face.texture;
        text.text = line;
    }

    public void HideMessage()
    {
        if (!enabled)
            return;
        if (animator.GetBool("Window"))
        {
            //EffectManager.instance.effectSounds[3].source.Play();
        }
        text.text = "";
        animator.SetBool("Window", false);
        rawImage.texture = faces[0].face.texture;
        //EffectManager.instance.effectSounds[4].source.Stop();
    }
}
