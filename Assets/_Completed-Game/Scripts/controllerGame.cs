using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerGame : MonoBehaviour
{
    // Use this for initialization
    private int myVariable;
    private int myGold;
    public Canvas cvSkin;
    public Text sumGold;
    public Text bestScore;
    public Text bestGold;
    public GameObject skinGO;
    public GameObject playerUFO;
    private int frameRate = 60;
    private void Awake()
    {
        Application.targetFrameRate = frameRate;
    }

    void Start()
    {
        myGold = PlayerPrefs.GetInt("Sum Gold");
        myVariable = PlayerPrefs.GetInt("Best Score");
        bestScore.text = myVariable.ToString();
        bestGold.text = myGold.ToString();
    }

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

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(checkSkinPlayer());
    }
    IEnumerator checkSkinPlayer()
    {
        if (cvSkin.enabled == true)
        {
            skinGO.SetActive(true);
            //sumGold.text = myGold.ToString();
        }
        yield return new WaitForEndOfFrame();
    }
}
