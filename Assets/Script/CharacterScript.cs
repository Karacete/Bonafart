using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float yatayHareket;
    private int runSpeed;
    private int jumpSpeed;
    private bool zipladiMi;
    private Animator animasyon;
    private SpriteRenderer sr;
    private ADManagerScript script;
    private LoadSceneManagerScript loadScript;
    private AudioSource jump;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animasyon = GetComponent<Animator>();
        runSpeed = 500;
        jumpSpeed = 500;
        zipladiMi = false;
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = false;
        animasyon.SetBool("zýplamaBittiMi", true);
        animasyon.SetBool("kosmaBittiMi", true);
        script = GameObject.FindWithTag("AD").GetComponent<ADManagerScript>();
        loadScript = GameObject.FindWithTag("Load").GetComponent<LoadSceneManagerScript>();
        jump=GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        
        rb.velocity = new Vector3(yatayHareket * Time.deltaTime * runSpeed, rb.velocity.y, 0);
        if (!animasyon.GetBool("kosmaBittiMi"))
            StartCoroutine(KonumDegisikigi());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Ziplama();
        if (Input.GetKeyDown(KeyCode.D))
            ÝleriHareket();
        if (Input.GetKeyDown(KeyCode.A))
            GeriHareket();
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            Dur();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            zipladiMi = false;
            animasyon.SetBool("zýplamaBittiMi", true);
        }

        if (collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("FireBall"))
        {
            collision.collider.transform.SetParent(null);
            script.ShowInterstitial();
        }

        if (collision.gameObject.CompareTag("Limit"))
        {
            runSpeed = 500;
            if (sr.flipY)
            {
                sr.flipY = false;
                rb.gravityScale = 2.65f;
            }

            else if (!sr.flipY)
            {
                sr.flipY = true;
                rb.gravityScale = -2.65f;
            }
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            loadScript.Load(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.Save();
        }

        if (collision.gameObject.CompareTag("Engel"))
            runSpeed = 0;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StartPoint"))
        {
            runSpeed = 500;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Engel"))
            runSpeed = 500;
    }
    public void ÝleriHareket()
    {
        yatayHareket = 1;
        sr.flipX = false;
        animasyon.Play("Kosma");
        animasyon.SetBool("kosmaBittiMi", false);
    }

    public void GeriHareket()
    {
            yatayHareket = -1;
            sr.flipX = true;
            animasyon.Play("Kosma");
            animasyon.SetBool("kosmaBittiMi", false);
    }

    public void Dur()
    {
        yatayHareket = 0;
        animasyon.SetBool("kosmaBittiMi", true);
    }

    public void Ziplama()
    {
        if (!zipladiMi)
        {
            if (sr.flipY)
                rb.AddForce(new Vector2(0, -jumpSpeed));
            else
                rb.AddForce(new Vector2(0, jumpSpeed));
            zipladiMi = true;
            jump.Play();
            animasyon.Play("Zýplama");
            animasyon.SetBool("zýplamaBittiMi", false);
        }
    }
    IEnumerator KonumDegisikigi()
    {
        float oncekiKonum = gameObject.transform.position.x;
        yield return new WaitForSeconds(0.025f);
        float sonrakiKonum = gameObject.transform.position.x;
        if (oncekiKonum == sonrakiKonum)
        {
            runSpeed = 0;
            if (!sr.flipY)
                rb.AddForce(-transform.up * 30);
            else if (sr.flipY)
                rb.AddForce(transform.up * 30);
        }
    }
}
