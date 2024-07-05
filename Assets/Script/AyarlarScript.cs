using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AyarlarScript : MonoBehaviour
{
    [Header("Kayit")]
    [SerializeField]
    private GameObject clearButton;
    [Header("Dil")]
    [SerializeField]
    private GameObject englishButton;
    [SerializeField]
    private GameObject turkishButton;
    [Header("EminMisin")]
    [SerializeField]
    private GameObject EminMisinPanel;
    [SerializeField]
    private GameObject TesekkurPanel;
    [SerializeField]
    private GameObject GenelAyarPanel;
    [Header("Kalite")]
    [SerializeField]
    private GameObject yuksekButton;
    [SerializeField]
    private GameObject dusukButton;
    [Header("Ses")]
    [SerializeField]
    private GameObject sesButton;
    [SerializeField]
    private GameObject sessizButton;

    private void Start()
    {
        TesekkurPanel.SetActive(false);
        EminMisinPanel.SetActive(false);
        GenelAyarPanel.SetActive(true);
        if (PlayerPrefs.HasKey("Language"))
        {
            switch (PlayerPrefs.GetInt("Language"))
            {
                case 0:
                    DilAyari(0);
                    break;
                case 1:
                    DilAyari(1);
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Language", 0);
            DilAyari(0);
        }
        if (PlayerPrefs.HasKey("Volume"))
        {
            switch (PlayerPrefs.GetInt("Volume"))
            {
                case 0:
                    SesAyari(true);
                    break;
                case 1:
                    SesAyari(false);
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Volume", 0);
            SesAyari(false);
        }
        if (PlayerPrefs.GetInt("Scene") != 0)
            clearButton.SetActive(true);
    }
    public void AyarlarKapat()
    {
        SceneManager.LoadScene(0);
    }
    public void Tesekkurler(bool kapansinMi)
    {
        if (kapansinMi)
        {
            TesekkurPanel.SetActive(false);
            GenelAyarPanel.SetActive(true);
        }
        else
        {
            GenelAyarPanel.SetActive(false);
            TesekkurPanel.SetActive(true);
        }
    }
    public void KayitSilme()
    {
        GenelAyarPanel.SetActive(false);
        EminMisinPanel.SetActive(true);
    }
    public void SesAyari(bool isSound)
    {
        if (isSound)
        {
            sesButton.SetActive(false);
            sessizButton.SetActive(true);
            AudioListener.volume = 0;
        }
        else if (!isSound)
        {
            sessizButton.SetActive(false);
            sesButton.SetActive(true);
            AudioListener.volume = 1;
        }
        PlayerPrefs.SetInt("Volume", Convert.ToInt32(AudioListener.volume));
        PlayerPrefs.Save();
    }
    public void KaliteAyari(int quality)
    {
        if (quality > 0)
        {
            dusukButton.SetActive(false);
            yuksekButton.SetActive(true);
        }
        else if (quality < 0)
        {
            yuksekButton.SetActive(false);
            dusukButton.SetActive(true);
        }
        QualitySettings.SetQualityLevel(quality);
    }
    public void DilAyari(int id)
    {
        if (id == 0)
        {
            turkishButton.SetActive(false);
            englishButton.SetActive(true);
        }
        else if (id == 1)
        {
            englishButton.SetActive(false);
            turkishButton.SetActive(true);
        }
    }
    public void Evet()
    {
        EminMisinPanel.SetActive(false);
        GenelAyarPanel.SetActive(true);
        PlayerPrefs.DeleteAll();
        clearButton.SetActive(false);
    }
    public void Hayir()
    {
        EminMisinPanel.SetActive(false);
        GenelAyarPanel.SetActive(true);
    }
}
