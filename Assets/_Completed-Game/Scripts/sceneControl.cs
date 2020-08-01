//using GoogleMobileAds.Api;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneControl : MonoBehaviour
{
    //InterstitialAd interstitial;
    public GameObject goAdVideo;
    public GameObject goeReload;
    private void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-8146090352984302~7814917551";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-8146090352984302~7814917551";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK. 
        //MobileAds.Initialize(appId);
        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8146090352984302/1552940110";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-8146090352984302/1552940110";
#else
        string adUnitId = "unexpected_platform";
#endif

        //// Initialize an InterstitialAd.
        //interstitial = new InterstitialAd(adUnitId);
        //// Create an empty ad request.
        //AdRequest request = new AdRequest.Builder().Build();
        //// Load the interstitial with the request.
        //interstitial.LoadAd(request);
        //// Called when an ad request has successfully loaded.
        //interstitial.OnAdLoaded += HandleOnAdLoaded;
        //// Called when an ad request failed to load.
        //interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        //// Called when an ad is shown.
        //interstitial.OnAdOpening += HandleOnAdOpened;
        //// Called when the ad is closed.
        //interstitial.OnAdClosed += HandleOnAdClosed;
        //// Called when the ad click caused the user to leave the application.
        //interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
    }

    public void HandleOnAdLoaded(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    //public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    //{
    //    MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
    //                        + args.Message);
    //}

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    public void loadScenePlay()
    {
        //if (interstitial.IsLoaded())
        //{
        //    interstitial.Show();
        //}
        //else
        //{
        //    MonoBehaviour.print("Don't Show AD");
        //}
        SceneManager.LoadScene(1);
    }

    public void closeBtnAdVideo()
    {
        goAdVideo.SetActive(false);
        goeReload.SetActive(true);
    }
}
