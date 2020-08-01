using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopGround : MonoBehaviour
{
    public GameObject groundAfter;
    public GameObject groundBefore;
    Vector3 posGrouBeforeNow;

    // When this game object intersects a collider with 'is trigger' checked, 
    // store a reference to that collider in a variable named 'other'..
    void OnTriggerEnter(Collider other)
    {
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.tag == "Player")
        {
            posGrouBeforeNow = groundBefore.transform.position;
            float posGrouAfter = groundAfter.transform.position.z;
            float khoangcachGr = 40.0f;
            float moveToGroundBefore = posGrouAfter + khoangcachGr;
            // Ground 2 đổi vị trí
            // Lấy trục z của ground5 + khoang cach ground
            groundBefore.transform.position = new Vector3(posGrouBeforeNow.x, 0.0f, moveToGroundBefore);
        }
    }
}
