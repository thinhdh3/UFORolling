using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteoriteDie : MonoBehaviour
{
    public Canvas m_gameOverPopup;
    private PlayerController playerdie;
    int textDia;
    public Text diaText;

    private void Start()
    {
        diaText = GameObject.Find("CanvasTime/DiamondText").GetComponent<Text>();
        m_gameOverPopup = GameObject.Find("CanvasReload").GetComponent<Canvas>();
    }

    public void makeDeadplayer()
    {
        Time.timeScale = 0.0f;
    }

    void OnTriggerEnter(Collider other)
    {
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.tag == "Player")
        {
            textDia = int.Parse(diaText.text);
            if (textDia == 0)
            {
                this.gameObject.SetActive(false);
                ShowGameOverPopup();
                playerdie = other.gameObject.GetComponent<PlayerController>();
                playerdie.makeDeadplayer();
            }
        }
    }

    public void ShowGameOverPopup()
    {
        m_gameOverPopup.enabled = true;
    }
}
