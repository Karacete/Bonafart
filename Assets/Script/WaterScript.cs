using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Water"))
            collision.collider.transform.SetParent(null);
    }
}
