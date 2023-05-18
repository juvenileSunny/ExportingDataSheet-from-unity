using System.Collections;
using System.IO;
using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class PlayerMovementData
{
    public float TimeElapsed;
    public Vector3 PlayerPosition;
    public Quaternion PlayerRotation;
}

[Serializable]
public class PlayerMovementDataList
{
    public List<PlayerMovementData> data;
}

public class PlayerDataLogger : MonoBehaviour
{
    public GameObject playerObject;
    public float loggingInterval;

    public static float logStartTime;
    public static float logElapsedTime;

    private List<PlayerMovementData> playerDataList = new List<PlayerMovementData>();
    private string dataFileName;

    void Start()
    {
        Debug.Log("Starting logger");

        loggingInterval = 0.1f;

        logStartTime = Time.time;
        logElapsedTime = 0f;

        playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject == null)
        {
            Debug.LogError("Player object not found");
            return;
        }

        dataFileName = Application.dataPath + "/playerData.json";

        Debug.Log("Logger started, saving data to: " + dataFileName);
       
        StartCoroutine(RecordPlayerData());
    }

    void Update()
    {
        logElapsedTime = Time.time - logStartTime;
    }

    public IEnumerator RecordPlayerData()
    {
        Debug.Log("Starting data recording");

        yield return new WaitForSeconds(0.1f);

        InvokeRepeating("LogPlayerData", 0, loggingInterval);
    }

    public void OnApplicationQuit()
    {
        Debug.Log("Application quitting, saving data");

        SaveAndClose();
    }

    public void OnDisable()
    {
        Debug.Log("Logger disabled, saving data");

        SaveAndClose();
    }

    public void SaveAndClose()
    {
        Debug.Log("Saving data: " + playerDataList.Count + " entries");

        if (playerDataList.Count == 0)
        {
            Debug.Log("No data to save");
            return;
        }

        var dataList = new PlayerMovementDataList { data = playerDataList };
        string jsonData = JsonUtility.ToJson(dataList, prettyPrint: true);
        File.WriteAllText(dataFileName, jsonData);

        logElapsedTime = 0f;
    }

    public void LogPlayerData()
    {
        var playerData = new PlayerMovementData 
        {
            TimeElapsed = logElapsedTime,
            PlayerPosition = playerObject.transform.position,
            PlayerRotation = playerObject.transform.rotation,
        };

        playerDataList.Add(playerData);

        Debug.Log("Recorded data: " + playerData.TimeElapsed);
    }
}
