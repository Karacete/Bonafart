using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject continueButton;
    private GameObject script;
    public void Start()
    {
        SaveLoadScript.Load();
        if (File.Exists("gamesave.bin"))
        {
            if (SaveData.scene > 0)
                continueButton.SetActive(true);
        }
        else
            continueButton.SetActive(false);
        AudioListener.volume = SaveData.volume;
        script = GameObject.FindWithTag("Load");
    }
    private void Awake()
    {
        SaveLoadScript.Load();
    }
    public void OyunaBasla()
    {
        script.GetComponent<LoadSceneManagerScript>().Load(2);
    }
    public void AyarlarAc()
    {
        SceneManager.LoadScene(1);
    }
    public void DevamEt()
    {
        SaveLoadScript.Load();
        script.GetComponent<LoadSceneManagerScript>().Load(SaveData.scene);
    }
    public void CikisYap()
    {
        Application.Quit();
    }
}
