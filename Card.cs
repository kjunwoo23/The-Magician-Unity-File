using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardType;
    public float speed;
    public float knock;
    bool first = true;

    void OnTriggerEnter2D(Collider2D collider)
    {
        bool miss = false;
        if (collider.tag == "Enemy" && (cardType == 1 || first))
        {
            if (collider.GetComponent<Enemy>() != null)
                collider.GetComponent<Enemy>().curTime = Random.Range(-1.000f, 0.500f);
            else if (collider.GetComponent<Enemy2>() != null)
                collider.GetComponent<Enemy2>().hp--;
            else if (collider.GetComponent<Enemy3>() != null)
            {
                if (collider.GetComponent<Enemy3>().area)
                {
                    int ran = Random.Range(1, 11);
                    if (ran <= 3) collider.GetComponent<Enemy3>().curTime = 0;
                    else
                    {
                        EffectManager.instance.effectSounds[38].source.Play();
                        miss = true;
                    }
                    collider.GetComponent<Enemy3>().area = false;
                }
                else collider.GetComponent<Enemy3>().curTime = 0;
            }

            if (!miss)
            {
                EffectManager.instance.effectSounds[2].source.Play();
                if (transform.rotation.y == 0)
                    collider.GetComponent<Rigidbody2D>().velocity += new Vector2(knock, 0);
                else
                    collider.GetComponent<Rigidbody2D>().velocity -= new Vector2(knock, 0);
            }

            if (cardType == 0)
                Destroy(gameObject);
            first = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyCard", 1);
    }

    // Update is called once per frame
    void Update()
    {  

    }
    public void DestroyCard()
    {
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        if (transform.rotation.y == 0)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.position -= new Vector3(0, speed * Time.deltaTime * 0.1f, 0);
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            transform.position -= new Vector3(0, speed * Time.deltaTime * 0.1f, 0);
        }
    }
}
