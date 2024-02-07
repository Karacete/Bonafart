using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AyarlarScript : MonoBehaviour
{
    [SerializeField]
    private GameObject clearButton;
    [SerializeField]
    private GameObject englishButton;
    [SerializeField]
    private GameObject turkishButton;
    [SerializeField]
    private GameObject EminMisinPanel;
    [SerializeField]
    private GameObject yuksekButton;
    [SerializeField]
    private GameObject dusukButton;
    private void Start()
    {
        if (File.Exists("gamesave.bin"))
        {
            clearButton.SetActive(true);
            if (SaveData.language == 0)
            {
                englishButton.SetActive(false);
                turkishButton.SetActive(true);
            }
            else if (SaveData.language == 1)
            {
                turkishButton.SetActive(false);
                englishButton.SetActive(true);
            }
        }
        else
        {
            SaveData.scene = 0;
            clearButton.SetActive(false);
            englishButton.SetActive(false);
            turkishButton.SetActive(true);
        }
    }
    public void AyarlarKapat()
    {
        SceneManager.LoadScene(0);
    }
    public void KayitSilme()
    {
        EminMisinPanel.SetActive(true);
    }
    public void KaliteAyari(int quality)
    {
        if (quality > 0)
        {
            yuksekButton.SetActive(false);
            dusukButton.SetActive(true);
        }
        else if (quality < 0)
        {
            dusukButton.SetActive(false);
            yuksekButton.SetActive(true);
        }
        QualitySettings.SetQualityLevel(quality);
    }
    public void DilAyari(int id)
    {
        if (id == 0)
        {
            englishButton.SetActive(false);
            turkishButton.SetActive(true);
        }
        else if (id == 1)
        {
            turkishButton.SetActive(false);
            englishButton.SetActive(true);
        }
    }
    public void Evet()
    {
        EminMisinPanel.SetActive(false);
        File.Delete("gamesave.bin");
        clearButton.SetActive(false);
    }
    public void Hayir()
    {
        EminMisinPanel.SetActive(false);
    }
}
