//using GoogleMobileAds.Api;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class skinController : MonoBehaviour
{
    public Text goldText;
    public Text[] priceText;
    public Text warningText;
    public GameObject[] btnSkin;
    public GameObject[] btnChoose;
    public GameObject[] imgApply;
    public GameObject[] SkinBall;
    public Button[] btnClick;
    public Button[] btnApply;
    public GameObject[] btnBuyGO;
    public Button[] btnBuy;
    public GameObject btnCancel;
    public Canvas cvConfirmSkin;
    private int sumGold;
    public int[] price;
    private float timeRemaining;
    private string[] values;
    private string[] valuesChoose;

    private int[] mySkin;
    private string[] valuePay;
    private int myGold;
    private string[] valuesBuy;
    public CameraController cameraControl;
    //private BannerView bannerView;

    private void Awake()
    {
        cvConfirmSkin.enabled = true;
        values = new string[9];
        valuesChoose = new string[9];

        btnChoose = new GameObject[9];
        imgApply = new GameObject[9];
        SkinBall = new GameObject[9];
        btnSkin = new GameObject[9];
        btnClick = new Button[9];
        btnApply = new Button[9];
        priceText = new Text[9];
        mySkin = new int[9];
        valuePay = new string[9];

        btnBuyGO = new GameObject[9];
        btnBuy = new Button[9];
        valuesBuy = new string[9];

        for (int i = 0; i < 9; i++)
        {
            values[i] = "BtnSkin" + i;
            valuesChoose[i] = "BtnChoose" + i;
            valuesBuy[i] = "BtnBuy" + i;
            valuePay[i] = "Pay Skin" + i;
            btnBuyGO[i] = GameObject.Find("/CanvasConfirm/" + valuesBuy[i]);
            btnBuy[i] = GameObject.Find("/CanvasConfirm/" + valuesBuy[i]).GetComponent<Button>();
            // Button nhận sự kiện click để mua Skin
            btnClick[i] = GameObject.Find("/CanvasSkin/" + values[i]).GetComponent<Button>();
            btnSkin[i] = GameObject.Find("/CanvasSkin/" + values[i]);
            SkinBall[i] = GameObject.Find("SkinGame/SkinBall" + i);
            // Button nhận sự kiện click để apply Skin
            btnChoose[i] = GameObject.Find("/CanvasSkin/BigChoose/" + valuesChoose[i]);
            btnApply[i] = GameObject.Find("/CanvasSkin/BigChoose/" + valuesChoose[i]).GetComponent<Button>();
            // Image Apply được Active đúng với ID Button Apply
            imgApply[i] = GameObject.Find("/CanvasSkin/BigChoose/" + valuesChoose[i] + "/ImgChoose");

            // Giá Skin Text trên CV
            priceText[i] = GameObject.Find("/CanvasSkin/" + values[i] + "/price/TextPrice").GetComponent<Text>();
            mySkin[i] = PlayerPrefs.GetInt(valuePay[i]);

            if (mySkin[i] == i)
            {
                SkinBall[i].GetComponent<RotatorSkin>().enabled = true;
                btnSkin[i].SetActive(false);
                btnChoose[i].SetActive(true);
            }
        }
        warningText = GameObject.Find("/CanvasSkin/WarningText").GetComponent<Text>();
        cameraControl = GameObject.Find("Main Camera").GetComponent<CameraController>();
        btnCancel = GameObject.Find("/CanvasConfirm/BtnCloseSkin");

        btnApply[0].onClick.AddListener(delegate { applySkin(0); });
        btnApply[1].onClick.AddListener(delegate { applySkin(1); });
        btnApply[2].onClick.AddListener(delegate { applySkin(2); });
        btnApply[3].onClick.AddListener(delegate { applySkin(3); });
        btnApply[4].onClick.AddListener(delegate { applySkin(4); });
        btnApply[5].onClick.AddListener(delegate { applySkin(5); });
        btnApply[6].onClick.AddListener(delegate { applySkin(6); });
        btnApply[7].onClick.AddListener(delegate { applySkin(7); });
        btnApply[8].onClick.AddListener(delegate { applySkin(8); });
    }


    private void Start()
    {
        myGold = PlayerPrefs.GetInt("Sum Gold");
        int idApply = PlayerPrefs.GetInt("Skin Apply");
        loadSumGold();
        imgApply[idApply].SetActive(true);
        price = new int[9];
        for (int i = 0; i < 9; i++)
        {
            price[i] = int.Parse(priceText[i].text);
            btnBuyGO[i].SetActive(false);
        }
        btnCancel.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine(testPopup());
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
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

    IEnumerator testPopup()
    {
        sumGold = int.Parse(goldText.text);
        if (warningText.text != "")
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                warningText.text = "";
            }
        }
        yield return new WaitForEndOfFrame();
    }

    void applySkin(int idChoose)
    {
        imgApply[idChoose].SetActive(true);
        PlayerPrefs.SetInt("Skin Apply", idChoose);

        for (int value = 0; value < 9; value++)
        {
            if (value != idChoose)
            {
                imgApply[value].SetActive(false);
            }
        }
    }

    public void callPopupConfirm(int idSkin)
    {
        btnCancel.SetActive(true);
        btnBuyGO[idSkin].SetActive(true);
        btnBuy[idSkin].onClick.AddListener(delegate { paySkinGame(idSkin); });
    }

    public void offConfirm()
    {
        for (int i = 0; i < 9; i++)
        {
            btnBuyGO[i].SetActive(false);
        }
        btnCancel.SetActive(false);
    }

    public void clickBack()
    {
        cameraControl.loadScenePlayer();
        offConfirm();
    }

    // Function thanh toán Skin
    public void paySkinGame(int number)
    {
        string[] bienPay;
        bienPay = new string[9];
        // If Pay Button opened is when click on will two case happen.
        if (btnSkin[number].activeInHierarchy == true)
        {
            // Confirm the total Gold is less than the value Skin wants to Pay?
            if (sumGold < price[number])
            {
                showPopup();
                offConfirm();
            }
            // If the total Gold is greater than the Skin Price, the Complete Skin purchase process will take place
            else if (sumGold > price[number])
            {
                // Pass the correct ID of the skin you want to buy when Clicking Button
                bienPay[number] = "Pay Skin" + number;
                // Subtract the purchase value of the total money
                int hieuGold = sumGold - price[number];
                PlayerPrefs.SetInt("Sum Gold", hieuGold);
                PlayerPrefs.SetInt(bienPay[number], number);
                // Update Text Gold When completing the Pay
                loadSumGoldUp();
                // Close SKinPay Button has just paid
                btnSkin[number].SetActive(false);
                btnChoose[number].SetActive(true);
                SkinBall[number].GetComponent<RotatorSkin>().enabled = true;
                // Close UI Confirm
                offConfirm();
            }
        }
    }

    void loadSumGold()
    {
        goldText.text = myGold.ToString();
    }

    void loadSumGoldUp()
    {
        int valueGold = PlayerPrefs.GetInt("Sum Gold");

        goldText.text = valueGold.ToString();
    }
    
    void showPopup()
    {
        timeRemaining = 2.0f;

        warningText.text = "Not enough gold";
        if (timeRemaining == 0)
        {
            warningText.text = "";
        }
    }
}
