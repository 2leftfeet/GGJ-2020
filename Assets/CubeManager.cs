using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] GameObject[] cubes;
    [SerializeField] Vector3[] positions;

    [SerializeField] GameObject prefab;
    private int length;
    
    void Start()
    {
        length = cubes.Length;
    }

    void Update()
    {
        for(int i = 0; i < length; i++)
        {
            if (!cubes[i])
            {
                cubes[i] = Instantiate(prefab, positions[i], Quaternion.identity);
            }
        }   
    }
}
