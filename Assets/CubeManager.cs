using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] GameObject[] cubes;
    [SerializeField] Vector3[] positions;

    [SerializeField] GameObject powerCube;
    [SerializeField] Vector3 powerCubePosition;

    [SerializeField] GameObject prefab;
    [SerializeField] GameObject powerCubePrefab;
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

        if (!powerCube)
        {
            powerCube = Instantiate(powerCubePrefab, powerCubePosition, Quaternion.identity);
        }
    }
}
