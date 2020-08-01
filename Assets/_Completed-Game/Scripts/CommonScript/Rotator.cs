using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    private Rigidbody rb;
    private float minPosPick = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Before rendering each frame..
    void Update()
    {
        // Rotate the game object that this script is attached to by 15 in the X axis,
        // 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
        // rather than per frame.
        StartCoroutine(checkStatusGO());
    }

    IEnumerator checkStatusGO()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * 4);
        Vector3 pickY = this.transform.position;
        float fallPick = pickY.y;
        if (fallPick < minPosPick)
        {
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
        }
        //if (gameObject.activeInHierarchy == true)
        //{
        //    rb.isKinematic = false;
        //}
        yield return null;
    }

}