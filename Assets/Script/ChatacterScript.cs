using UnityEngine;
using UnityEngine.SceneManagement;

public class ChatacterScript : MonoBehaviour
{
    private Rigidbody2D gravity;
    private Rigidbody2D rb;
    private float yatayHareket;
    private int runSpeed;
    private int jumpSpeed;
    private bool zipladiMi;
    private Animator animasyon;
    private SpriteRenderer sr;
    private GameObject script;
    private GameObject loadScript;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animasyon = GetComponent<Animator>();
        runSpeed = 500;
        jumpSpeed = 250;
        zipladiMi = false;
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = false;
        animasyon.SetBool("zýplamaBittiMi", true);
        gravity = GetComponent<Rigidbody2D>();
        script = GameObject.FindWithTag("AD");
        loadScript = GameObject.FindWithTag("Load");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) && !zipladiMi || yatayHareket > 0 && !zipladiMi)
        {
            sr.flipX = false;
            animasyon.Play("Kosma");
        }
        if (Input.GetKey(KeyCode.A) && !zipladiMi || yatayHareket < 0 && !zipladiMi)
        {
            sr.flipX = true;
            animasyon.Play("Kosma");
        }
        if (Input.GetKeyDown(KeyCode.Space))
            Ziplama();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(yatayHareket * Time.deltaTime * runSpeed, rb.velocity.y, 0);
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
            script.GetComponent<ADManagerScript>().ShowInterstitial();
        }
        if (collision.gameObject.CompareTag("Limit"))
        {

            if (sr.flipY)
            {
                sr.flipY = false;
                gravity.gravityScale = 1;
            }

            else if (!sr.flipY)
            {
                sr.flipY = true;
                gravity.gravityScale = -1;
            }

        }
        if (collision.gameObject.CompareTag("Door"))
        {
            loadScript.GetComponent<LoadSceneManagerScript>().Load(SceneManager.GetActiveScene().buildIndex + 1);
            SaveData.scene = SceneManager.GetActiveScene().buildIndex + 1;
            SaveLoadScript.Save();
        }
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
            animasyon.Play("Zýplama");
            animasyon.SetBool("zýplamaBittiMi", false);
        }
    }
}
