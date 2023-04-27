using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPostion : MonoBehaviour
{
    public Transform cameraPostion;
    void Update()
    {
        transform.position = cameraPostion.position;

    }
}
