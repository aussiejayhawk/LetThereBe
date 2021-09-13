using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStartCubesScript : MonoBehaviour
{
    public CubeManagerScript cubeManager;
    public PowerCubeScript cubePrefab;
    //public XmlManagerScript XmlManager;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        CreateCubes();
        Debug.Log("Start Function is running on Create Cubes Script");
    }

    public void CreateCubes()
    {
        List<Vector3> randomCubeLayout = XmlManagerScript.Instance.GetCubePositions();
        
        foreach (var cubePos in randomCubeLayout)
        {
            PowerCubeScript newCube = Instantiate(cubePrefab, cubePos,
                Random.rotation, transform);
            newCube.transform.parent = null;
            cubeManager.powerCubeList.Add(newCube);
        }
    }

}
