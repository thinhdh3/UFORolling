using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindMoveController : MonoBehaviour
{
    public float windspeed;
    Rigidbody myrigi;
    // Use this for initialization
    private PlayerController playerdie;
    public Canvas m_gameOverPopup;
    int textDia;
    public Text diaText;

    void Awake()
    {
        myrigi = GetComponent<Rigidbody>();
        if (transform.localRotation.z > 0)
        {
            myrigi.AddForce(new Vector3(0, 0, 1) * windspeed, ForceMode.Impulse);
        }
        else myrigi.AddForce(new Vector3(0, 0, -1) * windspeed, ForceMode.Impulse);
    }

    void Start()
    {
        m_gameOverPopup = GameObject.Find("CanvasReload").GetComponent<Canvas>();
        diaText = GameObject.Find("CanvasTime/DiamondText").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textDia = int.Parse(diaText.text);
            if (textDia == 0)
            {
                ShowGameOverPopup();
                playerdie = other.gameObject.GetComponent<PlayerController>();
                playerdie.makeDeadplayer();
            }
        }
    }

    //Chuc nang lam wind dung lai
    public void removeForce()
    {
        myrigi.velocity = new Vector3(0, 0, 0);
    }

    public void ShowGameOverPopup()
    {
        m_gameOverPopup.enabled = true;
    }
}
