using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevelAdditive(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Additive);
    }

    public void UnloadLevel(int levelIndex)
    {
        SceneManager.UnloadSceneAsync(levelIndex);
    }
}
