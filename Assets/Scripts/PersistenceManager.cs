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

    // Awake is called before the first frame update
    void Awake()
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
}
