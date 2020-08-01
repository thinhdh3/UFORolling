using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goalUfo : MonoBehaviour
{
    private float _wallMaxX;
    private float _wallMinX;
    // Use this for initialization
    void Start()
    {
        //random the height of the pipe in first time
        randomWall();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WallMove")
        {
            randomWall();
        }
    }

    private void randomWall()
    {
        //the min/max pipe can random
        _wallMinX = 2.0f;
        _wallMaxX = -3.0f;
        Vector3 pos = this.transform.position;
        // random position of wall enim
        //pos.y = Random.Range(_wallMinY, _wallMaxY);
        float randomX = Random.Range(_wallMinX, _wallMaxX);
        pos.x = randomX;
        // random size wall enim
        // set value for rota present when Player move to
        this.transform.position = pos;
    }
}
