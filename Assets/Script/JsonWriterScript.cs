using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class JsonWriterScript : MonoBehaviour
{
    [System.Serializable]
    public class Player
    {
        public string name;
        public int health;
        public int damage;
        public int defence;
    }

    public Player myPlayer = new Player();
    
    
    public void outputJSON()
    {
        string strOutput = JsonUtility.ToJson(myPlayer);


        File.WriteAllText(Application.dataPath + "/text.json", strOutput);


        {

        } 
    }
}
