using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rocketFireMove : MonoBehaviour
{
    // Use this for initialization
    public GameObject rocketFire;
    public GameObject playerUFO;

    public void callRocketFire()
    {
        float fireRate = 0.5f;
        float nextFire = 0;
        if (Time.time > nextFire)
        {
            bool facingRight = true;
            nextFire = Time.time + fireRate;
            Vector3 posUFO = playerUFO.transform.position;
            float rocketX = Random.Range(posUFO.x - 1.5f, posUFO.x + 1.5f);
            Vector3 posGodRocket = new Vector3(rocketX, posUFO.y + 2.0f, posUFO.z + 20);
            if (facingRight)
            {
                Instantiate(rocketFire, posGodRocket, Quaternion.Euler(new Vector3(-90.0f, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(rocketFire, posGodRocket, Quaternion.Euler(new Vector3(-90.0f, 0, 180)));
            }
        }
    }


}
