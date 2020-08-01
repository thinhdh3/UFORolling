using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneControl : MonoBehaviour
{
    //InterstitialAd interstitial;
    public GameObject goAdVideo;
    public GameObject goeReload;

    public void HandleOnAdLoaded(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

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
        SceneManager.LoadScene(1);
    }

    public void closeBtnAdVideo()
    {
        goAdVideo.SetActive(false);
        goeReload.SetActive(true);
    }
}
