using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireWallDie : MonoBehaviour
{
    public Canvas m_gameOverPopup;
    public Text diaText;
    public PlayerController playerdie;
    private float _wallMaxY;
    private float _wallMinY;
    private float _wallMaxX;
    private float _wallMinX;
    private float _sizeMinX;
    private float _sizeMaxX;
    //private float _sizeMinY;
    //private float _sizeMaxY;
    private int textDia;
    // Use this for initialization
    void Start()
    {
        //the min/max pipe can random
        this._wallMaxY = 2.5f;
        this._wallMinY = 1.0f;
        this._wallMinX = 3.0f;
        this._wallMaxX = -3.0f;
        this._sizeMinX = 1.5f;
        this._sizeMaxX = 2.5f;
        //this._sizeMinY = 1.0f;
        //this._sizeMaxY = 2.0f;
        //random the height of the pipe in first time
        randomWall();
    }

    private void OnTriggerEnter(Collider other)
    {
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.tag == "Player")
        {
            textDia = int.Parse(diaText.text);
            if (textDia == 0)
            {
                ShowGameOverPopup();
                playerdie.makeDeadplayer();
            }
        }
        if (other.gameObject.tag == "WallMove")
        {
            randomWall();
        }
    }

    private void randomWall()
    {
        Vector3 pos = transform.position;
        Vector3 sizeWall = transform.localScale;
        // random position of wall enim
        pos.y = Random.Range(_wallMinY, _wallMaxY);
        pos.x = Random.Range(_wallMinX, _wallMaxX);
        // random size wall enim
        sizeWall.x = Random.Range(_sizeMinX, _sizeMaxX);
        // set value for rota present when Player move to
        this.transform.position = pos;
        this.transform.localScale = sizeWall;
    }

    public void ShowGameOverPopup()
    {
        m_gameOverPopup.enabled = true;
    }
}
