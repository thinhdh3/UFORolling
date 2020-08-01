using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundMove : MonoBehaviour {
    public float speed;
    private Rigidbody rb;

	// Update is called once per frame
	void Update () {
        moveBall();
    }

    public void moveBall()
    {
        Vector3 moveball = new Vector3(0, 0, -1);
        transform.Translate(moveball * speed * Time.deltaTime);
    }

}
