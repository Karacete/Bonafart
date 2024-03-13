using UnityEngine;

public class FinalCharacterScript: MonoBehaviour
{
    [SerializeField]
    private GameObject melek;
    [SerializeField]
    private GameObject seytan;
    private bool melekisActive;
    [SerializeField]
    private GameObject cehennemCanvas;
    [SerializeField]
    private GameObject dunyaCanvas;
    void Start()
    {
        melekisActive = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            if (melekisActive)
            {
                melek.SetActive(false);
                seytan.SetActive(true);
                melekisActive = false;                
            }
            else
            {
                seytan.SetActive(false);
                melek.SetActive(true);
                melekisActive = true;               
            }
        }

    }
}
