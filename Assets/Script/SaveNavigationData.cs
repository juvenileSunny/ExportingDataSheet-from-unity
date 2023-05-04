using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveNavigationData : MonoBehaviour
{
    public Transform playerTransform;

    private List<Vector3> navigationData = new List<Vector3>();
    private string filePath;

    void Start()
    {
        filePath = Application.dataPath + "/navigation_data.json";
    }

    void Update()
    {
        // Record the player's position every frame
        navigationData.Add(playerTransform.position);
    }

    void OnApplicationQuit()
    {
        // Convert the navigation data to a JSON string
        string json = JsonUtility.ToJson(navigationData);

        // Save the JSON string to a file
        File.WriteAllText(filePath, json);

        Debug.Log("Navigation data saved to " + filePath);
    }
}