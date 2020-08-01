using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomBuild : MonoBehaviour
{
    private float _wallMaxY;
    private float _wallMinY;

    // Use this for initialization
    void Start()
    {
        //random the height of the pipe in first time
        randomWall();
    }

    private void randomWall()
    {
        //the min/max pipe can random
        this._wallMinY = -1.0f;
        this._wallMaxY = 10.0f;
        Vector3 pos = transform.position;
        // random position of wall enim
        pos.y = Random.Range(_wallMinY, _wallMaxY);
        // random size wall enim
        this.transform.position = pos;
    }
}
