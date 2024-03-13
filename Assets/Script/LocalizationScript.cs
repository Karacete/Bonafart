using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalizationScript : MonoBehaviour
{
    private bool aktifMi = false;
    private int language;
    public void Start()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            language = PlayerPrefs.GetInt("Language");
            StartCoroutine(SetLocale(language));
        }
        else
        {
            PlayerPrefs.SetInt("Language", 0);
            StartCoroutine(SetLocale(0));
        }
    }
    public void DilDegistir(int id)
    {
        if (aktifMi)
            return;
        StartCoroutine(SetLocale(id));
        PlayerPrefs.SetInt("Language", id);
        PlayerPrefs.Save();
    }
    IEnumerator SetLocale(int siraNumara)
    {
        aktifMi = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[siraNumara];
        aktifMi = false;
    }
}
