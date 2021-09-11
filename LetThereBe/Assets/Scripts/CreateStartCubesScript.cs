using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStartCubesScript : MonoBehaviour
{
    public CubeManagerScript cubeManager;
    public PowerCubeScript cubePrefab;
    public XmlManagerScript XmlManager;
    
    void Start()
    {
        CreateCubes();
    }

    void CreateCubes()
    {
        foreach (var cubePos in XmlManager.cubePositions)
        {
            PowerCubeScript newCube = Instantiate(cubePrefab, cubePos,
                Random.rotation, transform);
            newCube.transform.parent = null;
            cubeManager.powerCubeList.Add(newCube);
        }
    }

}
