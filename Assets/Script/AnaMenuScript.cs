using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject continueButton;
    [SerializeField]
    private GameObject surePanel;
    [SerializeField]
    private GameObject anaPanel;
    private GameObject script;
    public void Start()
    {
        if (PlayerPrefs.HasKey("Language"))
            PlayerPrefs.GetInt("Language");
        else
            PlayerPrefs.SetInt("Langauge", 0);

        if (PlayerPrefs.HasKey("Volume"))
            PlayerPrefs.GetInt("Volume");
        else
            PlayerPrefs.SetInt("Volume", 1);

        if (PlayerPrefs.HasKey("Scene"))
            continueButton.SetActive(true);
        else
            continueButton.SetActive(false);

        anaPanel.SetActive(true);
        script = GameObject.FindWithTag("Load");
        AudioListener.volume = PlayerPrefs.GetInt("Volume");
    }
    public void OyunaBasla()
    {
        if (PlayerPrefs.HasKey("Scene"))
        {
            anaPanel.SetActive(false);
            surePanel.SetActive(true);
        }
        else
            script.GetComponent<LoadSceneManagerScript>().Load(3);

    }
    public void OyunuSifirla()
    {
        script.GetComponent<LoadSceneManagerScript>().Load(3);
    }
    public void OyunuSifirlama()
    {
        surePanel.SetActive(false);
        anaPanel.SetActive(true);
    }
    public void AyarlarAc()
    {
        SceneManager.LoadScene(1);
    }
    public void DevamEt()
    {
        script.GetComponent<LoadSceneManagerScript>().Load(PlayerPrefs.GetInt("Scene"));
    }
    public void SonsuzMod()
    {
        script.GetComponent<LoadSceneManagerScript>().Load(2);
    }
}
