using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public Transform dirPos;
    public Vector2 dirSize;
    public int type;
    public float time;
    public int dir;
    public float velocity;
    public float confSpeed;
    public SpriteRenderer sprite;
    public Transform col;
    public Transform target;
    public Dummy dummy;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.transform.position.y > transform.position.y + 5 || Player.instance.transform.position.y < transform.position.y - 5) return;
        if (type == 1)
        {
            if (time < 0)
            {
                time = Random.Range(1.000f, 5.000f);
                velocity = Random.Range(0.100f, 1.500f);
                dir = Random.Range(-1, 2);
            }
            time -= Time.deltaTime;
            transform.position = col.position;
            transform.position += new Vector3(velocity * Time.deltaTime * dir, 0, 0);
            col.position = transform.position;
            //if (!animator.GetBool("panic"))
            {
                if (dummy.enabled == true)
                    target.position = dummy.transform.position;
                else
                    target.position = Player.instance.transform.position;
                if (transform.position.x < target.position.x) sprite.flipX = true;
                if (transform.position.x > target.position.x) sprite.flipX = false;
            }
        }
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(dirPos.position, dirSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Enemy")
            {
                if (collider.GetComponent<Enemy>() != null)
                    collider.GetComponent<Enemy>().curTime = 2;
                if (collider.GetComponent<Enemy2>() != null)
                    if (collider.GetComponent<Enemy2>().dmg == false)
                        collider.GetComponent<Enemy2>().dmgTime -= Time.deltaTime;
                if (collider.GetComponent<Enemy3>() != null)
                    collider.GetComponent<Enemy3>().area = true;
                if (collider.GetComponent<Enemy4>() != null)
                    collider.GetComponent<Enemy4>().area = true;
            }
        }
        if (Player.instance.alternative && Player.instance.isDisguise && flag == false)
        {
            StartCoroutine("Confusion");
            //animator.SetBool("panic", true);
        }
        else if (Player.instance.alternative && !Player.instance.isDisguise)
        {
            StopCoroutine("Confusion");
            //animator.SetBool("panic", false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(dirPos.position, dirSize);
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
