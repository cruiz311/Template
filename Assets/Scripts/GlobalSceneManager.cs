using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalSceneManager : MonoBehaviour
{
    private static GlobalSceneManager instance;

    private List<string> loadedScenes = new List<string>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        if (!loadedScenes.Contains(sceneName))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            loadedScenes.Add(sceneName);
        }
    }

    public void UnloadScene(string sceneName)
    {
        if (loadedScenes.Contains(sceneName))
        {
            SceneManager.UnloadSceneAsync(sceneName);
            loadedScenes.Remove(sceneName);
        }
    }

    public void UnloadAllScenes()
    {
        foreach (string sceneName in loadedScenes)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
        loadedScenes.Clear();
    }
}
