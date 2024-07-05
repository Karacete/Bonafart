using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject pauseCanvas;
    [SerializeField]
    private GameObject tusCanvas;
    void Start()
    {
        StartCoroutine(TextGosterim());
        Time.timeScale = 1.0f;
    }
    private IEnumerator TextGosterim()
    {
        yield return new WaitForSeconds(5);
        text.SetActive(false);
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
