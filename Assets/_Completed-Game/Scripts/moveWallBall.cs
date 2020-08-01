using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWallBall : MonoBehaviour
{

    // Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
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
        StartCoroutine(moveWallofUFO());
    }

    IEnumerator moveWallofUFO()
    {
        // Get Position of Player Ball
        Vector3 localNow = playerBall.transform.position;
        float localUp = localNow.z + wallBally;
        Vector3 pos = new Vector3(0, 1.0f, localUp);
        this.transform.position = pos;
        rb.AddForce(pos);
        yield return new WaitForEndOfFrame();
    }

}
