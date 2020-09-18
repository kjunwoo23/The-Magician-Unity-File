using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    [System.Serializable]
    public class Scene
    {
        public Texture[] texture;
    }

    public RawImage scene;
    public Scene scenes;

    int i = 0;
    int sceneStop = 0;
    int sceneSize;
    bool stay = false;
    bool skip = false;
    void Start()
    {
        if (!enabled) return;
        scene.texture = scenes.texture[i];
        sceneSize = scenes.texture.Length;
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
            scene.enabled = true;
            scene.texture = scenes.texture[i];
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
                scene.texture = scenes.texture[i];
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
            if (sceneStop == 0)
            {
                scene.texture = scenes.texture[i];
                sceneStop++;
            }
            if (i == sceneSize - 2)
            {
                i++;
                Player.instance.skill = false;
                scene.enabled = false;
                skip = true;
            }
            if (Input.GetKeyDown(KeyCode.Space) && i < sceneSize - 2)
            {
                i++;
                scene.texture = scenes.texture[i];
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player")
        {
            Player.instance.skill = false;
            sceneStop = 0;
            scene.enabled = false;
            stay = false;
        }
    }
}
