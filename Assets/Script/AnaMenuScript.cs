using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject continueButton;
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

        script = GameObject.FindWithTag("Load");
        AudioListener.volume = PlayerPrefs.GetInt("Volume");
    }
    public void OyunaBasla()
    {
        script.GetComponent<LoadSceneManagerScript>().Load(3);
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
