using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.transform.position.y > transform.position.y + 5 || Player.instance.transform.position.y < transform.position.y - 5) return;
        if (Player.instance.fade.enabled && animator.GetBool("CurtainUp"))
            animator.SetBool("CurtainUp", false);
        if(!Player.instance.fade.enabled && !animator.GetBool("CurtainUp"))
            animator.SetBool("CurtainUp", true);
    }
}
