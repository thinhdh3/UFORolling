using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEarth : MonoBehaviour
{
    // Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
    private Rigidbody rb;
    public GameObject playerBall;
    public float wallBally;
    Vector3 posStart;
    // At the start of the game..
    public void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();
        posStart = this.transform.position;
    }

    // Each physics step..
    void Update()
    {
        StartCoroutine(posEarthofUFO());
    }

    IEnumerator posEarthofUFO()
    {
        // Get Position of Player Ball
        Vector3 localNow = playerBall.transform.position;

        float localUp = localNow.z + wallBally;
        Vector3 pos = new Vector3(posStart.x, posStart.y, localUp);
        this.transform.position = pos;
        rb.AddForce(pos);
        yield return new WaitForEndOfFrame();
    }
}
