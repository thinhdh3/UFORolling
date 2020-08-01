using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRandomAll : MonoBehaviour
{
    public float scaleFactor = 0.1f;
    // Each physics step..
    void Start()
    {
        //Get instantiated mesh
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        // Randomly change vertices
        Vector3[] myVertices = mesh.vertices;
        int p = 0;
        while (p < myVertices.Length)
        {
            myVertices[p] += new Vector3(Random.Range(-0.3F, 0.3F), Random.Range(-0.3F, 0.3F), Random.Range(-0.3F, 0.3F));
            p++;
        }
        mesh.vertices = myVertices;
        mesh.RecalculateNormals();
    }
}
