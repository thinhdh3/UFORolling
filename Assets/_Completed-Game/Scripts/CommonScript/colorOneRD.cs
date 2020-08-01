using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorOneRD : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

}
