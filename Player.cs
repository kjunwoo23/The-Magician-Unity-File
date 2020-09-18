using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

    public bool isMemory;
    public bool skill = false;
    public float playerSize;
    public float playerSpeed, slowSpeed, defaultSpeed;
    public bool isWalk;
    public Animator animator;
    public Rigidbody2D myRigid;
    public Vector2 MousePosition;
    public Camera cam;
    public CinemachineVirtualCamera cm;
    public Animator EscDown;
    public Animator EscUp;
    public GameObject card0, card1;
    public Dummy dummy;
    public Transform cardShoot;
    public float cardCooltime0, cardCooltime1, cardCurtime0 = 0, cardCurtime1 = 0;
    public bool comboIng = false;
    public bool isPause = false, paused = false;
    public int deck;
    public bool reload = false;
    public float reloadCool, reloadCurrent;
    public Transform atkPos;
    public Vector2 atkSize;
    public float knock;
    public float dmgcool, dmgcoolMax;
    public int hits;
    public bool isHacking = false;
    public RawImage fade;
    public Animator walking;
    public SpriteRenderer sprite;
    public Color alpha;
    public bool isDisguise = false;
    public bool alternative = false;
    public bool noR;
    public Text cardNum;
    public Slider slider;
    public float disguiseCool, disguiseCur;
    public Image disguiseCoolImage;
    Color disguiseCoolImageColor;
    public bool leftWall, rightWall;
    public RawImage blur;
    public bool jokerOn;
    public int BWJoker;
    public float bgmTime, bgmTimeTmp;
    public Animator joker;
    public GameObject tarotMagician;
    public bool guideOn;
    public Animator guideCard;
    public Text guideText;
    public SpriteRenderer gas;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        reloadCurrent = reloadCool;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "LeftWall")
            leftWall = true;
        else if (collision.collider.tag == "RightWall")
            rightWall = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "LeftWall")
            leftWall = false;

        else if (collision.collider.tag == "RightWall")
            rightWall = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && isDisguise == false)
        {
            if (deck == 0)
                Debug.Log("GameOver");
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(atkPos.position, atkSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Enemy")
                {
                    if (collider.GetComponent<Enemy2>() != null) if (!collider.GetComponent<Enemy2>().dmg) return;
                    if (collider.GetComponent<Enemy3>() != null) if (!collider.GetComponent<Enemy3>().dmg) return;
                    collider.GetComponent<Animator>().SetTrigger("dmg");
                    if ((isHacking || !skill) && dmgcool < 0)
                    {
                        if (collider.transform.position.x > transform.position.x)
                        {
                            collider.GetComponent<Rigidbody2D>().velocity += new Vector2(knock * 2, 0);
                            StartCoroutine(Damaged(true));
                            myRigid.velocity -= new Vector2(knock, 0);
                        }
                        if (collider.transform.position.x < transform.position.x)
                        {
                            collider.GetComponent<Rigidbody2D>().velocity -= new Vector2(knock * 2, 0);
                            StartCoroutine(Damaged(false));
                            myRigid.velocity += new Vector2(knock, 0);
                        }
                        animator.SetTrigger("damaged");
                        Invoke("DamagedSound", 0.27f);
                        if (isHacking || reload)
                        {
                            animator.SetBool("hacking", false);
                            if (deck > 10) deck -= 10;
                            else deck = 0;
                            /*
                            if (deck > 15) deck -= 15;
                            else deck = 0;*/
                        }
                        else
                        {
                            if (deck > 10) deck -= 10;
                            else deck = 0;
                        }
                        if (collider.GetComponent<Enemy4>() != null)
                            collider.GetComponent<Enemy4>().animator.SetTrigger("attack");
                        dmgcool = dmgcoolMax;
                    }
                    if (collider.GetComponent<Enemy>() != null)
                        collider.GetComponent<Enemy>().curTime = Random.Range(-1.000f, 0.500f);
                    else if (collider.GetComponent<Enemy3>() != null)
                        collider.GetComponent<Enemy3>().curTime = Random.Range(-1.000f, 0.500f);
                }
            }
            isHacking = false;
            EffectManager.instance.effectSounds[6].source.Pause();
            reload = false;
            EffectManager.instance.effectSounds[7].source.Stop();
            reloadCurrent = reloadCool;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && isDisguise == false)
        {
            if (deck == 0)
                Debug.Log("GameOver");
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(atkPos.position, atkSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Enemy")
                {
                    if (collider.GetComponent<Enemy2>() != null) if (!collider.GetComponent<Enemy2>().dmg) return;
                    if (collider.GetComponent<Enemy3>() != null) if (!collider.GetComponent<Enemy3>().dmg) return;
                    collider.GetComponent<Animator>().SetTrigger("dmg");
              
                    if ((isHacking || !skill) && dmgcool < 0)
                    {
                        if (collider.transform.position.x > transform.position.x)
                        {
                            collider.GetComponent<Rigidbody2D>().velocity += new Vector2(knock * 2, 0);
                            StartCoroutine(Damaged(true));
                            myRigid.velocity -= new Vector2(knock, 0);
                        }
                        if (collider.transform.position.x < transform.position.x)
                        {
                            collider.GetComponent<Rigidbody2D>().velocity -= new Vector2(knock * 2, 0);
                            StartCoroutine(Damaged(false));
                            myRigid.velocity += new Vector2(knock, 0);
                        }
                        animator.SetTrigger("damaged");
                        Invoke("DamagedSound", 0.27f);
                        if (isHacking || reload)
                        {
                            animator.SetBool("hacking", false);
                            if (deck > 10) deck -= 10;
                            else deck = 0;
                            /*
                            if (deck > 15) deck -= 15;
                            else deck = 0;*/
                        }
                        else
                        {
                            if (deck > 10) deck -= 10;
                            else deck = 0;
                        }
                        if (collider.GetComponent<Enemy4>() != null)
                            collider.GetComponent<Enemy4>().animator.SetTrigger("attack");
                        dmgcool = dmgcoolMax;
                    }
                    if (collider.GetComponent<Enemy>() != null)
                        collider.GetComponent<Enemy>().curTime = Random.Range(-1.000f, 0.500f);
                    else if (collider.GetComponent<Enemy3>() != null)
                        collider.GetComponent<Enemy3>().curTime = Random.Range(-1.000f, 0.500f);
                }
            }
            isHacking = false;
            EffectManager.instance.effectSounds[6].source.Pause();
            reload = false;
            EffectManager.instance.effectSounds[7].source.Stop();
            reloadCurrent = reloadCool;
        }
    }

    IEnumerator Damaged(bool right)
    {
        for (float i = 0; i < 0.3f; i += Time.deltaTime)
        {
            if (right && transform.localScale.x < 0) sprite.flipX = true;
            if (!right && transform.localScale.x > 0) sprite.flipX = false;
            yield return null;
        }
        sprite.flipX = false;
    }


    public void DamagedSound()
    {
        EffectManager.instance.effectSounds[9].source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
            StartCoroutine("IsPause");
        if (isPause && !paused) return;
        if (alternative && cardNum.color != Color.red)
            cardNum.color = Color.red;
        else if (!alternative && cardNum.color != Color.white)
            cardNum.color = Color.white;

        dmgcool -= Time.deltaTime;
        if (animator.GetBool("disguise"))
        {
            disguiseCoolImage.fillAmount += Time.deltaTime / 5.0f;
        }
        else
        {
            disguiseCur -= Time.deltaTime;
            disguiseCoolImageColor = disguiseCoolImage.color;
            disguiseCoolImageColor.a = disguiseCur / disguiseCool;
            disguiseCoolImage.color = disguiseCoolImageColor;
        }
        isWalk = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A));
        if (!skill)
        {
            if (Input.GetKey(KeyCode.D) && !rightWall)
            {
                animator.SetBool("walking", true);
                transform.position += new Vector3(1, 0, 0) * playerSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A) && !leftWall)
            {
                animator.SetBool("walking", true);
                transform.position += new Vector3(-1, 0, 0) * playerSpeed * Time.deltaTime;
            }
            else
            {
                animator.SetBool("walking", false);

            }
        }
        if (isMemory) return;
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = slowSpeed;
            if (isDisguise && !fade.enabled)
            {
                StopCoroutine("Disguise");
                animator.SetBool("disguise", false);
                disguiseCur = disguiseCool;
                alpha = sprite.color;
                alpha.a = 1;
                sprite.color = alpha;
                isDisguise = false;
                EffectManager.instance.effectSounds[12].source.Stop();
                Dummy.instance.DestroyDummy();
            }
            //walking.speed = 0.5f;
        }
        else
        {
            walking.speed = 0.7f;
            playerSpeed = defaultSpeed;
        }
        if (reload == true && deck < 52)
        {
            reloadCurrent -= Time.deltaTime;
            if (reloadCurrent < 0)
            {
                deck += 5;
                reloadCurrent = reloadCool;
            }
        }
        if (deck > 52) deck = 52;
        if (deck < 0) deck = 0;

        if (Input.GetKeyDown(KeyCode.LeftShift) && !alternative)
        {
            reload = true;
            reloadCurrent = reloadCool;
            EffectManager.instance.effectSounds[7].source.Play();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            reload = false;
            EffectManager.instance.effectSounds[7].source.Stop();
        }
        if (Input.GetKeyDown(KeyCode.R) && !skill && deck > 0 && !isHacking && !alternative && !isDisguise && !noR)
        {
            alternative = true;
            StartCoroutine("LightOff");
        }
        if (Input.GetKeyDown(KeyCode.Q) && !skill && deck > 0 && !isDisguise && !isHacking && disguiseCur < 0)
        {
            animator.SetTrigger("disguisestart");
            StartCoroutine("Disguise");
        }
        if (Input.GetKeyDown(KeyCode.S) && jokerOn == false)
            StartCoroutine("Joker");
        if (isDisguise == true)
        {
            EffectManager.instance.effectSounds[12].source.pitch += Time.deltaTime;
        }

        if (skill == false)
        {
            if (Input.GetMouseButton(0))
            {
                if (cardCurtime0 <= 0 && comboIng == false && deck > 0 && reload == false && !PostItManager.instance.GetComponent<Animator>().GetBool("post"))
                {
                    animator.SetTrigger("cardthrow");
                    if (hits != 3)
                    {
                        hits++;
                        deck--;
                        EffectManager.instance.effectSounds[1].source.Play();
                        if (MousePosition.x > transform.position.x + 0.5 * playerSize)
                            Instantiate(card0, cardShoot.position, Quaternion.Euler(0, 0, -5.7f));
                        if (MousePosition.x < transform.position.x - 0.5 * playerSize)
                            Instantiate(card0, cardShoot.position, Quaternion.Euler(0, 180, -5.7f));
                        cardCurtime0 = cardCooltime0;
                    }
                    else if (hits == 3)
                    {
                        hits = 1;
                        deck--;
                        EffectManager.instance.effectSounds[10].source.Play();
                        if (MousePosition.x > transform.position.x + 0.5 * playerSize)
                            Instantiate(card1, cardShoot.position, Quaternion.Euler(0, 0, -5.7f));
                        if (MousePosition.x < transform.position.x - 0.5 * playerSize)
                            Instantiate(card1, cardShoot.position, Quaternion.Euler(0, 180, -5.7f));
                        cardCurtime0 = cardCooltime0 * 0.5f;
                    }
                }
            }
            if (Input.GetMouseButton(1))
            {
                if (cardCurtime1 <= 0 && deck > 0 && reload == false && !PostItManager.instance.GetComponent<Animator>().GetBool("post"))
                {
                    StartCoroutine(Combo());
                    cardCurtime1 = cardCooltime1;
                }
            }
        }
        cardCurtime0 -= Time.deltaTime;
        cardCurtime1 -= Time.deltaTime;

        MousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if (!DialogueManager.instance.animator.GetBool("Window"))
        {
            if (MousePosition.x > transform.position.x + 0.5 * playerSize)
                transform.localScale = new Vector3(1, 1, 1) * playerSize;
            if (MousePosition.x < transform.position.x - 0.5 * playerSize)
                transform.localScale = new Vector3(-1, 1, 1) * playerSize;
        }
        if (isHacking && isDisguise && !fade.enabled)
        {
            StopCoroutine("Disguise");
            disguiseCur = disguiseCool;
            alpha = sprite.color;
            alpha.a = 1;
            sprite.color = alpha;
            isDisguise = false;
            EffectManager.instance.effectSounds[12].source.Stop();
        }
    }

    IEnumerator Combo()
    {
        comboIng = true;
        if (deck > 0) deck --;
        EffectManager.instance.effectSounds[1].source.Play();
        animator.SetTrigger("cardthrow2");
        if (MousePosition.x > transform.position.x + 0.5 * playerSize)
            Instantiate(card0, cardShoot.position, Quaternion.Euler(0, 0, -5.7f));
        if (MousePosition.x < transform.position.x - 0.5 * playerSize)
            Instantiate(card0, cardShoot.position, Quaternion.Euler(0, 180, -5.7f));
        yield return new WaitForSeconds(0.4f);
        for (int i = 0; i < 4; i++)
        {
            if (deck > 0) deck--;
            EffectManager.instance.effectSounds[10].source.Play();
            if (MousePosition.x > transform.position.x + 0.5 * playerSize)
                Instantiate(card1, cardShoot.position, Quaternion.Euler(0, 0, -5.7f));
            if (MousePosition.x < transform.position.x - 0.5 * playerSize)
                Instantiate(card1, cardShoot.position, Quaternion.Euler(0, 180, -5.7f));
            yield return new WaitForSeconds(0.13f);
            if (i == 1)
                yield return new WaitForSeconds(0.08f);
        }
        comboIng = false;
    }
    IEnumerator LightOff()
    {
        animator.SetTrigger("lightoff");
        skill = true;
        animator.SetBool("walking", false);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition|RigidbodyConstraints2D.FreezeRotation;


        yield return new WaitForSeconds(0.2f);
        EffectManager.instance.effectSounds[31].source.Play();
        yield return new WaitForSeconds(0.2f);
        EffectManager.instance.effectSounds[32].source.Play();
        yield return new WaitForSeconds(0.3f);
        EffectManager.instance.effectSounds[33].source.Play();
        yield return new WaitForSeconds(0.3f);
        EffectManager.instance.effectSounds[34].source.Play();
        yield return new WaitForSeconds(1.0f);
        EffectManager.instance.effectSounds[35].source.Play();
        yield return new WaitForSeconds(1.0f);


        SoundManager.instance.bgmPlayer.volume *= 0.2f;

        alpha = sprite.color;
        alpha = Color.black;
        alpha.a = 0.6f;
        sprite.color = alpha;
        fade.enabled = true;
        isDisguise = true;
        EffectManager.instance.effectSounds[8].source.Play();
        EffectManager.instance.effectSounds[14].source.Play();
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation;
        skill = false;
        EffectManager.instance.effectSounds[39].source.Play();
        while (deck > 3)
        {
            deck--;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.3f);
        EffectManager.instance.effectSounds[39].source.Stop();
        yield return new WaitForSeconds(14.7f);
        fade.enabled = false;
        alpha = sprite.color;
        alpha = Color.white;
        alpha.a = 1;
        sprite.color = alpha;
        isDisguise = false;
        EffectManager.instance.effectSounds[14].source.Stop();
        EffectManager.instance.effectSounds[13].source.Play();

        SoundManager.instance.bgmPlayer.volume = slider.value;

    }
    IEnumerator Disguise()
    {
        animator.SetBool("walking", false);
        skill = true;
        if (deck > 0) deck--;
        EffectManager.instance.effectSounds[15].source.Play();
        yield return new WaitForSeconds(0.2f*1.5f);
        if (deck > 0) deck--;
        EffectManager.instance.effectSounds[16].source.Play();
        yield return new WaitForSeconds(0.2f*1.5f);
        if (deck > 0) deck--;
        EffectManager.instance.effectSounds[17].source.Play();
        yield return new WaitForSeconds(0.2f*1.5f);
        if (deck > 0) deck--;
        EffectManager.instance.effectSounds[18].source.Play();
        yield return new WaitForSeconds(0.4f*1.5f);
        if (deck > 0) deck--;
        EffectManager.instance.effectSounds[11].source.Play();
        alpha = sprite.color;
        alpha.a = 0.7f;
        sprite.color = alpha;
        dummy.transform.position = transform.position;
        dummy.transform.localScale = transform.localScale;
        dummy.GetComponent<SpriteRenderer>().enabled = true;
        dummy.enabled = true;
        dummy.time = 0;
        skill = false;
        EffectManager.instance.effectSounds[12].source.Play();
        EffectManager.instance.effectSounds[12].source.pitch = 1.0f;
        animator.SetBool("disguise", true);
        disguiseCoolImageColor = disguiseCoolImage.color;
        disguiseCoolImageColor.a = 1;
        disguiseCoolImage.color = disguiseCoolImageColor;
        disguiseCoolImage.fillAmount = 0;
        isDisguise = true;
        yield return new WaitForSeconds(5);
        animator.SetBool("disguise", false);
        EffectManager.instance.effectSounds[12].source.Stop();
        EffectManager.instance.effectSounds[13].source.Play();
        alpha = sprite.color;
        alpha.a = 1;
        sprite.color = alpha;
        disguiseCur = disguiseCool;
        isDisguise = false;
    }

    IEnumerator Joker()
    {
        jokerOn = true;
        joker.SetBool("BWAppear", true);
        EffectManager.instance.effectSounds[36].source.Play();

        while (TestGray.instance.intensity < 1)
            {
                TestGray.instance.intensity += 0.02f;
                TestGray.instance.shadowThreshold += 0.008f;
                yield return new WaitForSeconds(0.01f);
            }
            EffectManager.instance.effectSounds[0].source.Play();
            TestGray.instance.intensity = 1;
            TestGray.instance.shadowThreshold = 0.4f;

            SoundManager.instance.bgmSounds[0].clip = SoundManager.instance.bgmPlayer.clip;
            bgmTime = SoundManager.instance.bgmPlayer.time;
            SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[6].clip;
            SoundManager.instance.bgmPlayer.time = 122;
            SoundManager.instance.bgmPlayer.Play();
            joker.SetBool("BWAppear", false);
            BWJoker = 2;
        while (SoundManager.instance.bgmPlayer.time < 172)
        {
            yield return new WaitForSeconds(0.5f);
            if (deck > 0)
            {
                deck--;
                EffectManager.instance.effectSounds[41].source.Play();
            }
            yield return null;
        }
        //EffectManager.instance.effectSounds[41].source.Stop();
        joker.SetBool("CAppear", true);
            EffectManager.instance.effectSounds[37].source.Play();
            while (TestGray.instance.intensity > 0)
            {
                TestGray.instance.intensity -= 0.02f;
                TestGray.instance.shadowThreshold -= 0.008f;
                yield return new WaitForSeconds(0.01f);
            }
            EffectManager.instance.effectSounds[0].source.Play();
            TestGray.instance.intensity = 0;
            TestGray.instance.shadowThreshold = 0;

        SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[0].clip;
        SoundManager.instance.bgmPlayer.time = bgmTime;
        SoundManager.instance.bgmPlayer.Play();

            joker.SetBool("CAppear", false);
            BWJoker = 1;
        
        jokerOn = false;
    }

    IEnumerator IsPause()
    {
        paused = true;
        isPause = !isPause;
        if (isPause)
        {
            blur.enabled = true;
            EffectManager.instance.effectSounds[28].source.Play();
            EscDown.SetBool("Esc", true);
            EscUp.SetBool("Esc", true);
            //yield return new WaitForSeconds(0.2f);
            cm.enabled = false;
            Time.timeScale = 0f;
        }
        else
        {
            blur.enabled = false;
            Time.timeScale = 1f;
            cm.enabled = true;
            EscDown.SetBool("Esc", false);
            EscUp.SetBool("Esc", false);
            yield return new WaitForSeconds(0.1f);
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        paused = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(atkPos.position, atkSize);
    }
    public void OnClickHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnClickFool()
    {
        tarotMagician.SetActive(true);
        guideText.text = "직원들의 패턴이 눈에 보이게 됩니다.";
        guideCard.SetTrigger("appear");
        guideOn = true;
    }
    public void OnClickMagician()
    {
        tarotMagician.SetActive(false);
        guideText.text = "직원들의 패턴이 눈에 보이지 않게 됩니다.";
        guideCard.SetTrigger("appear");
        guideOn = false;
    }
}
