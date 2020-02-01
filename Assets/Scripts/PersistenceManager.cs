using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for holding all the data between scenes
/// as well as loading different Scenes
/// </summary>
public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager instance;
    Dictionary<string, PersistentSet> persistentSets = new Dictionary<string, PersistentSet>();

    // Awake is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        foreach(KeyValuePair<string, PersistentSet> set in persistentSets)
        {
            if (set.Value.levelIndex == level)
                set.Value.gameObject.SetActive(true);
            else
                set.Value.gameObject.SetActive(false);
        }
    }

    public void RegisterGO(GameObject go, string uniqueString)
    {
        PersistentSet ps = new PersistentSet()
        {
            gameObject = go,
            levelIndex = go.scene.buildIndex
        };

        if (!persistentSets.ContainsKey(uniqueString))
        {
            persistentSets.Add(uniqueString, ps);
            DontDestroyOnLoad(go);
        }
        else
        {
            Debug.LogWarning(go.name + " is unlucky and will not reincarnate for this scene");
            Destroy(go);
        }
    }

    private struct PersistentSet
    {
        public GameObject gameObject;
        public int levelIndex;
    }
}
