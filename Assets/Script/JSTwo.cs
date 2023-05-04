using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSTwo : MonoBehaviour
{
     public Transform playerTransform;

    private List<Vector3> navigationData = new List<Vector3>();

    void Update()
    {
        // Record the player's position every frame
        navigationData.Add(playerTransform.position);
    }

    public void SaveNavigationDataToJson(string filePath)
    {
        // Convert the navigation data to a JSON string
        string json = JsonUtility.ToJson(navigationData);

        // Save the JSON string to a file
        // File.WriteAllText(filePath, json);
    }
    void OnApplicationQuit()
    {
        SaveNavigationDataToJson(Application.persistentDataPath + "/navigation_data.json" );
    }

    
}
