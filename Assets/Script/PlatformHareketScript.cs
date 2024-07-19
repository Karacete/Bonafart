using UnityEngine;

public class PlatformHareketScript : MonoBehaviour
{
    [SerializeField]
    private bool isEndlessPlatform;
    [SerializeField]
    private float hiz;
    private Vector3 baslangicPozisyon;
    [SerializeField]
    private Vector3 bitisPozisyon;
    [SerializeField]
    private GameObject platform;
    private void Start()
    {
        baslangicPozisyon = platform.transform.position;
        if (isEndlessPlatform)
            bitisPozisyon.x = baslangicPozisyon.x;
    }
    private void FixedUpdate()
    {
        if (platform.transform.position == baslangicPozisyon)
        {
            baslangicPozisyon = bitisPozisyon;
            if (gameObject.CompareTag("FireBall"))
                gameObject.transform.Rotate(180, 90, 0);
            if (baslangicPozisyon == bitisPozisyon)
                bitisPozisyon = platform.transform.position;
        }
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, baslangicPozisyon, Time.deltaTime * hiz);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.collider.transform.SetParent(transform);
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("FireBall"))
            collision.collider.transform.SetParent(null);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Ground"))
            collision.collider.transform.SetParent(null);
    }
}
