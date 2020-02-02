using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    public string uniqueString;
    public bool stayInAllScenes;
    public int sceneId;

    // Start is called before the first frame update
    void Start()
    {
        sceneId = gameObject.scene.buildIndex;
        PersistenceManager.instance.RegisterGO(gameObject, uniqueString);
    }
}
