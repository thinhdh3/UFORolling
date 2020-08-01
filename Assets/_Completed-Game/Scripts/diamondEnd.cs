using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diamondEnd : MonoBehaviour
{
    PlayerController playerdie;

    void OnTriggerEnter(Collider other)
    {
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.tag == "Player")
        {
            Destroy(GetComponent<MeshRenderer>());
        }
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
    }
}
