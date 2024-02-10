using System;
using System.IO;
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
        if (File.Exists("gamesave.bin"))
        {
            clearButton.SetActive(true);
            switch (SaveData.language)
            {
                case 0:
                    englishButton.SetActive(false);
                    turkishButton.SetActive(true);
                    break;
                case 1:
                    turkishButton.SetActive(false);
                    englishButton.SetActive(true);
                    break;
            }
            switch (SaveData.volume)
            {
                case 0:
                    sessizButton.SetActive(false);
                    sesButton.SetActive(true);
                    break;
                case 1:
                    sesButton.SetActive(false);
                    sessizButton.SetActive(true);
                    break;
            }
        }
        else
        {
            clearButton.SetActive(false);
            englishButton.SetActive(false);
            turkishButton.SetActive(true);
            sesButton.SetActive(false);
            sessizButton.SetActive(true);
            AudioListener.volume = 1;
        }
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
            sessizButton.SetActive(false);
            sesButton.SetActive(true);
            AudioListener.volume = 0;
        }
        else if (!isSound)
        {
            sesButton.SetActive(false);
            sessizButton.SetActive(true);
            AudioListener.volume = 1;
        }
        SaveData.volume = Convert.ToInt32(AudioListener.volume);
        SaveLoadScript.Save();
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
        GenelAyarPanel.SetActive(true);
        File.Delete("gamesave.bin");
        SaveData.scene = 0;
        SaveData.volume = 1;
        clearButton.SetActive(false);
    }
    public void Hayir()
    {
        EminMisinPanel.SetActive(false);
        GenelAyarPanel.SetActive(true);
    }
}
