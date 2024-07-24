using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class ADManagerScript : MonoBehaviour
{
    private string _adUnitId = "ca-app-pub-4552243857039919/8339173339";
    private LoadSceneManagerScript loadScript;
    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) => { });
        LoadInterstitialAd();
        loadScript = GameObject.FindWithTag("Load").GetComponent<LoadSceneManagerScript>();
    }
    private InterstitialAd _interstitialAd;
    public void LoadInterstitialAd()
    {
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }
        var adRequest = new AdRequest();
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    return;
                }
                _interstitialAd = ad;
            });
    }
    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            _interstitialAd.Show();
            RegisterEventHandlers(_interstitialAd);
        }
        else
        {
            loadScript.Load(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void RegisterEventHandlers(InterstitialAd interstitialAd)
    {
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            loadScript.Load(SceneManager.GetActiveScene().buildIndex);
        };
    }
}
