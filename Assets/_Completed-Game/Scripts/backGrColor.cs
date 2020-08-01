﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGrColor : MonoBehaviour {
    public Color colorBr;
	// Use this for initialization
	void Start () {
        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", colorBr);

        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);
    }
}
