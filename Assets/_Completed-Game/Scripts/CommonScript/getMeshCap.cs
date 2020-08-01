using UnityEngine;
using UnityEngine.SceneManagement;

public class getMeshCap : MonoBehaviour
{
    private Mesh mesh;
    public Vector3[] verticesCapsule;

    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        Mesh meshs = GetComponent<MeshFilter>().sharedMesh;
        verticesCapsule = mesh.vertices;
    }

    public void setMeshGame()
    {
        mesh.vertices = verticesCapsule;
        mesh.RecalculateNormals();
    }
}
