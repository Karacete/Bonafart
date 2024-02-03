using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Localization.Settings;
public class LocalizationScript : MonoBehaviour
{
    private bool aktifMi = false;
    public void Start()
    {
        if (File.Exists("gamesave.bin"))
            StartCoroutine(SetLocale(SaveData.language));
        else
        {
          StartCoroutine(SetLocale(0));
        }
    }
    public void DilDegistir(int id)
    {
        if (aktifMi)
            return;
        StartCoroutine(SetLocale(id));
        SaveData.language = id;
        SaveLoadScript.Save();
    }
    IEnumerator SetLocale(int siraNumara)
    {
        aktifMi = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[siraNumara];
        aktifMi = false;
    }
}
