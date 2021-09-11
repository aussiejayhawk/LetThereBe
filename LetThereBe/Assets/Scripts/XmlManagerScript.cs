using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XmlManagerScript : MonoBehaviour
{
    public List<Vector3> cubePositions;

    public File XMLfile; 
    
    public CubeDatabase cubeDB;

    public DatabaseDatabase dataDB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ImportXML()
    {
        //CreateAndFillCubeClass();
        
        XmlSerializer newXML = new XmlSerializer(typeof(DatabaseDatabase));
        FileStream stream = new FileStream(XMLfile, FileMode.Create);
        newXML.Serialize(stream, dataDB);
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
