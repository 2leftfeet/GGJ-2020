using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    public string uniqueString;

    // Start is called before the first frame update
    void Start()
    {
        PersistenceManager.instance.RegisterGO(gameObject, uniqueString);
    }
}
