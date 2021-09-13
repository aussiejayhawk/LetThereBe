using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XmlManagerScript : MonoBehaviour
{
    public static XmlManagerScript Instance;
    
    public List<Vector3> cubePositions;

    public string XMLfile; 
    
    public CubeDatabase cubeDB;

    public DatabaseDatabase dataDB;
    // Start is called before the first frame update

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        ImportXML();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Vector3> GetCubePositions()
    {
        List<Vector3> cubePositionsFromXML = new List<Vector3>();

        int numberOfDatabases = dataDB.listOfDatabases.Count;

        int whichDatabase = (Random.Range(0, numberOfDatabases));

        foreach (var standInCube in dataDB.listOfDatabases[whichDatabase].listOfCubes)
        {
            Vector3 cubePos = new Vector3(standInCube.xPos, standInCube.yPos, standInCube.zPos);
            cubePositionsFromXML.Add(cubePos);

        }
        
        return cubePositionsFromXML;
    }


    public void ImportXML()
    {
        //CreateAndFillCubeClass();
        
        XmlSerializer importedXML = new XmlSerializer(typeof(DatabaseDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/XML/cubeData.xml", FileMode.Open);
        dataDB = importedXML.Deserialize(stream) as DatabaseDatabase;
        stream.Close();
    }
    
    [System.Serializable]
    public class CubeDatabase
    {
        public List<StandInCube> listOfCubes = new List<StandInCube>();
    }
    
    [System.Serializable]
    public class DatabaseDatabase
    {
        public List<CubeDatabase> listOfDatabases= new List<CubeDatabase>();
    }
    
    

    [System.Serializable]
    public class StandInCube
    {
        public float xPos;
        public float yPos;
        public float zPos;
    }

}
