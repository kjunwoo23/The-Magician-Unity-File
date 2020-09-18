using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform pos;
    public Dummy dummy;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (Player.instance.skill == false)
                {
                    if (Player.instance.isDisguise && !Player.instance.fade.enabled)
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
                    StartCoroutine(DoorOpen(collision));
                }
            }
    }

    IEnumerator DoorOpen(Collider2D collision)
    {
        Player.instance.animator.SetBool("walking", false);
        if (Player.instance.deck > 0)
        {
            Player.instance.animator.SetBool("door", true);
            Player.instance.deck --;
            Player.instance.skill = true;
            Player.instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition|RigidbodyConstraints2D.FreezeRotation;
            yield return new WaitForSeconds(0.3f);
            if (Player.instance.deck > 0) Player.instance.deck --;
            yield return new WaitForSeconds(0.1f);
            EffectManager.instance.effectSounds[3].source.Play();
            yield return new WaitForSeconds(0.1f);
            if (Player.instance.deck > 0) Player.instance.deck --;
            yield return new WaitForSeconds(0.2f);
            //if (Player.instance.deck > 0) Player.instance.deck--;
            yield return new WaitForSeconds(0.2f);
            EffectManager.instance.effectSounds[40].source.Play();
            if (Player.instance.deck > 0) Player.instance.deck --;
            yield return new WaitForSeconds(0.3f);
            if (Player.instance.deck > 0) Player.instance.deck --;
            EffectManager.instance.effectSounds[4].source.Play();
            yield return new WaitForSeconds(0.3f);
            dummy.transform.position = Player.instance.transform.position;
            dummy.transform.localScale = Player.instance.transform.localScale;
            dummy.GetComponent<SpriteRenderer>().enabled = true;
            dummy.enabled = true;
            dummy.time = 0;
            Player.instance.gas.transform.position = dummy.transform.position;
            Player.instance.gas.enabled = true;
            //if (Player.instance.deck > 0) Player.instance.deck--;
            yield return new WaitForSeconds(1.2f);
            //if (Player.instance.deck > 0) Player.instance.deck--;
            collision.GetComponent<Transform>().position = new Vector3(pos.position.x, collision.GetComponent<Transform>().position.y, collision.GetComponent<Transform>().position.z);
            EffectManager.instance.effectSounds[5].source.Play();
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation;
            collision.GetComponent<Player>().skill = false;
            Player.instance.animator.SetBool("door", false);
            Invoke("GasDisappear", 5);
        }
    }
    
    public void GasDisappear()
    {
        Player.instance.gas.GetComponent<Animator>().SetTrigger("disappear");
        Invoke("NoGas", 1);
    }
    public void NoGas()
    {
        Player.instance.gas.enabled = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
