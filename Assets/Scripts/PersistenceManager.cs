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
            if (set.Value.persObj.sceneId == level)
                set.Value.gameObject.SetActive(true);
            else if (!set.Value.persObj.stayInAllScenes)
                set.Value.gameObject.SetActive(false);
        }   
    }

    public void RegisterGO(GameObject go, string uniqueString)
    {
        PersistentSet ps = new PersistentSet()
        {
            gameObject = go,
            persObj = go.GetComponent<PersistentObject>()
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

    private class PersistentSet
    {
        public GameObject gameObject;
        public PersistentObject persObj;
    }
}
