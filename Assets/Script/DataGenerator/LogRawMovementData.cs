using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using System;
using System.Linq;

public class LogRawMovementData : MonoBehaviour
{
    public GameObject trackedPlayer;
    //public GameObject trackedHand;
    //public GameObject trackedHeadOfPlayer;

    public float interval;
    public StreamWriter writer;
    public StreamWriter writerEvent;

    public static float startTime;
    public static float elapsedTime;

    private string folderName;

  

    // Start is called before the first frame update
    // void Awake()
    // {
    //     folderName = "RawMovementData";
       
    // }

    void Start()
    {
        interval = 0.1f;

        startTime = Time.time;
        elapsedTime = 0f;


        trackedPlayer = GameObject.FindGameObjectWithTag("Player");

       
        StartCoroutine(LogMovementAnalytics());

        

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(GetPersistencePath());

        elapsedTime = Time.time - startTime;
    }

    // public string GetPersistencePath()
    // {
    //     string path = Application.persistentDataPath.Substring(0, Application.persistentDataPath.Length);

    //     // Strip application name - not needed here
    //     //path = path.Substring(0, path.LastIndexOf('/'));
    //     return path + "/";


    // }

    public IEnumerator LogMovementAnalytics()
    {
        yield return new WaitForSeconds(0.1f);
        // folderName = "Analytics Data";

        // if(!Directory.Exists(Application.dataPath + "/" + folderName))
        // System.IO.Directory.CreateDirectory(Application.dataPath) + "/" + folderName);

        // string dir = Application.dataPath + "/" + folderName;
        string dir = Application.dataPath;

        // writer = System.IO.File.CreateText(dir + "/" + "user-" + AnalyticsSessionInfo.sessionId + ".csv");
        writer = System.IO.File.CreateText(dir + "/dt.csv");
        writer.Write("Elapsed Time (ms)");
        writer.Write(",");
        // writer.Write("Loaded Level Name");
        // writer.Write(",");
        // writer.Write("Event type");
        // writer.Write(",");
        writer.Write("Transform Pos X");
        writer.Write(",");
        writer.Write("Transform Pos Y");
        writer.Write(",");
        writer.Write("Transform Pos Z");
        writer.Write(",");
        writer.Write("Transform Rot X");
        writer.Write(",");
        writer.Write("Transform Rot Y");
        writer.Write(",");
        writer.Write("Transform Rot Z");
        writer.Write(",");
        writer.Write("Transform Rot W");





        writer.WriteLine();



        InvokeRepeating("startLoggingData", 0, interval);



    }

    public void OnApplicationQuit()
    {
        whenQuitted();


    }


    public void whenQuitted()
    {
        writer.WriteLine(elapsedTime);
        writer.Close();

        elapsedTime = 0f;

    }

    public void startLoggingData()
    {

        writer.Write(elapsedTime);
        // writer.Write(",");
        // writer.Write(Application.loadedLevelName);
        // writer.Write(",");
        // writer.Write("user tracking");
        writer.Write(",");
        writer.Write(trackedPlayer.transform.position.x);
        writer.Write(",");
        writer.Write(trackedPlayer.transform.position.y);
        writer.Write(",");
        writer.Write(trackedPlayer.transform.position.z);
        writer.Write(",");
        writer.Write(trackedPlayer.transform.rotation.x);
        writer.Write(",");
        writer.Write(trackedPlayer.transform.rotation.y);
        writer.Write(",");
        writer.Write(trackedPlayer.transform.rotation.z);
        writer.Write(",");
        writer.Write(trackedPlayer.transform.rotation.w);
   

      



        writer.WriteLine();





    }



}
