using UnityEngine;
using UnityEngine.SceneManagement;

public class getMeshCube : MonoBehaviour
{
    private Mesh mesh;
    public Vector3[] verticesCube;

    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        verticesCube = mesh.vertices;
    }

    public void setMeshGame()
    {
        mesh.vertices = verticesCube;
        mesh.RecalculateNormals();
    }
}
