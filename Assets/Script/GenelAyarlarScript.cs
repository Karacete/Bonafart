using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenelAyarlarScript : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject pauseCanvas;
    [SerializeField]
    private GameObject tusCanvas;
    [SerializeField]
    private Transform sinir1;
    [SerializeField]
    private Transform sinir2;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Slider katedilenYol;
    void Start()
    {
        StartCoroutine(YolKatetme());
        StartCoroutine(TextGosterim());
        Time.timeScale = 1.0f;
    }
    private IEnumerator TextGosterim()
    {
        yield return new WaitForSeconds(5);
        text.SetActive(false);
    }
    private IEnumerator YolKatetme()
    {
        float mesafe = Vector2.Distance(sinir1.position, sinir2.position);
        while (true)
        {
            katedilenYol.value = playerTransform.transform.position.x / mesafe;
            yield return null;
        }
    }
    public void Durdur()
    {
        Time.timeScale = 0f;
        tusCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
    }
    public void AnaSayfaGit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void DevamEt()
    {
        pauseCanvas.SetActive(false);
        tusCanvas.SetActive(true);
        Time.timeScale = 1f;
    }
    public void AyarlarAc()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void Cikis()
    {
        Application.Quit();
    }
}
