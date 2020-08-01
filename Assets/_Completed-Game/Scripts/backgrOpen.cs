using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backgrOpen : MonoBehaviour {

    void Start()
    {
        StartCoroutine(LoadScenePlay());
    }

    IEnumerator LoadScenePlay()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        while (!asyncLoad.isDone)
        {
            yield return new WaitForSecondsRealtime(3.0f);
        }
    }
}
