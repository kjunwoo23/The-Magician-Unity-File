using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    public RectTransform pos;
    public Animator animator;
    public float shake;
    float x, y, z, angle, time;

    // Start is called before the first frame update
    void Start()
    {
        x = pos.position.x;
        y = pos.position.y;
        z = pos.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 2) time += Time.deltaTime;
        if (time < 1.5) return;
        else if (time < 3) time = 4;
        if (animator.enabled) animator.enabled = false;
        if (angle > 360) angle = 0;
        angle += Time.deltaTime * 100;
        pos.position = new Vector3(x + Mathf.Sin(0.5f * angle * Mathf.Deg2Rad) * shake, y + Mathf.Sin(angle * Mathf.Deg2Rad) * shake, z);
    }
}
