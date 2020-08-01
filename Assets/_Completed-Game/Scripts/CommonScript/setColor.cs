using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setColor : MonoBehaviour
{
    public Color colorBr;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = colorBr;
    }

}
