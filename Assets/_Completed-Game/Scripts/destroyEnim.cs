using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnim : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject playerBall;
    public float wallBally;
    // At the start of the game..
    public void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();
    }

    // Each physics step..
    void Update()
    {
        StartCoroutine(posItemDestroy());
    }

    IEnumerator posItemDestroy()
    {
        // Get Position of Player Ball
        Vector3 localNow = playerBall.transform.position;
        float localUp = localNow.z - wallBally;
        Vector3 pos = new Vector3(0, 0.0f, localUp);
        Quaternion rotationSkin = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        this.transform.position = pos;
        this.transform.rotation = rotationSkin;
        rb.AddForce(pos);
        yield return new WaitForEndOfFrame();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Pick Up")
        //{
        //    Destroy(other.gameObject);
        //}
        //if (other.gameObject.tag == "Stone")
        //{
        //    Destroy(other.gameObject);
        //}
        if (other.gameObject.tag == "Diamond")
        {
            Destroy(other.gameObject);
        }
    }
}
