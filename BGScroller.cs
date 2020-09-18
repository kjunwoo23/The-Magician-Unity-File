using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.instance.skill)
        {
            if (Player.instance.transform.position.y > transform.position.y + 5 || Player.instance.transform.position.y < transform.position.y - 5) return;
            if (Input.GetKey(KeyCode.D) && !Player.instance.rightWall)
                meshRenderer.material.mainTextureOffset -= new Vector2(1, 0) * Player.instance.playerSpeed * Time.deltaTime * 0.02f;
            else if (Input.GetKey(KeyCode.A) && !Player.instance.leftWall)
                meshRenderer.material.mainTextureOffset -= new Vector2(-1, 0) * Player.instance.playerSpeed * Time.deltaTime * 0.02f;
        }
    }
}
