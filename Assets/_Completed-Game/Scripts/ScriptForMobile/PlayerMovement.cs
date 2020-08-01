//using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Joystick joystick;
    protected PlayerController playerControl;
    public GameObject skinGame;
    private Rigidbody rigi;
    public float driverLR;
    public float speed;
    //private BannerView bannerView;

    private void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-8146090352984302~7814917551";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        //MobileAds.Initialize(appId);
        this.RequestBanner();
        joystick = FindObjectOfType<Joystick>();
        playerControl = FindObjectOfType<PlayerController>();
        //skinGame = GameObject.Find("/Canvas/ImgSkinBall");
        rigi = GetComponent<Rigidbody>();


    }
    private void FixedUpdate()
    {
        if (skinGame.activeInHierarchy == false)
        {
            //Vector3 movement = new Vector3(joystick.Horizontal, 0.0f, 1);
            rigi.velocity = new Vector3(joystick.Horizontal * driverLR, rigi.velocity.y, speed);
            //rigi.AddForce(movement * speed);
        }
    }

    private void Update()
    {
        if (joystick.Horizontal > 0 || joystick.Vertical > 0)
        {
            playerControl.playGame();
        }
    }

    private void RequestBanner()
    {

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8146090352984302/4278976112";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-8146090352984302/4278976112";
#else
            string adUnitId = "unexpected_platform";
#endif

        //bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        //// Called when an ad request has successfully loaded.
        //bannerView.OnAdLoaded += HandleOnAdLoaded;
        //// Called when an ad request failed to load.
        //bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        //// Called when an ad is clicked.
        //bannerView.OnAdOpening += HandleOnAdOpened;
        //// Called when the user returned from the app after an ad click.
        //bannerView.OnAdClosed += HandleOnAdClosed;
        //// Called when the ad click caused the user to leave the application.
        //bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        //// Create an empty ad request.
        //AdRequest request = new AdRequest.Builder().Build();

        //// Load the banner with the request.
        //bannerView.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
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

    //public void destroyAdBanner()
    //{
    //    bannerView.Destroy();
    //}
}
