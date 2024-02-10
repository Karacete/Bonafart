using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System;
public class ADManagerScript : MonoBehaviour
{
    private InterstitialAd gecisReklami;
    private GameObject loadScript;
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestInterstitial();
        loadScript = GameObject.FindWithTag("Load");
    }
    public void RequestInterstitial()
    {      
        string reklamID = "ca-app-pub-4552243857039919/8339173339";
        if (gecisReklami != null)
        {
            gecisReklami.Destroy();
            gecisReklami = null;
        }
        var request = new AdRequest();
        InterstitialAd.Load(reklamID, request, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogError("Reklam yüklenmedi ve " + error + "hatasý döndürdü");
                return;
            }
            gecisReklami = ad;
            RegisterEventHandlers(gecisReklami);
        });
    }
    public void ShowInterstitial()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestInterstitial();
        if (gecisReklami != null && gecisReklami.CanShowAd())
        {
            gecisReklami.Show();
        }            
        else
            Debug.LogError("Ad is not ready yet");
    }
    private void RegisterEventHandlers(InterstitialAd ad)
    {
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        ad.OnAdFullScreenContentClosed += () =>
        {
            loadScript.GetComponent<LoadSceneManagerScript>().Load(SceneManager.GetActiveScene().buildIndex);
        };
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            RequestInterstitial();
        };
    }
}
