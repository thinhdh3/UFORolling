using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroyGO : MonoBehaviour
{
    public Canvas m_gameOverPopup;
    public PlayerController playControll;
    public GameObject GoReload;
    public Text scoreText;

    void OnTriggerEnter(Collider other)
    {
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.tag == "Player")
        {
            ShowGameOverPopup();
            playControll.makeDeadplayer();
        }
    }

    public void ShowGameOverPopup()
    {
        int score = int.Parse(scoreText.text);
        if(score == 0)
        {
            m_gameOverPopup.enabled = true;
            GoReload.SetActive(true);
        }
        else
        {
            m_gameOverPopup.enabled = true;
        }
    }


}
