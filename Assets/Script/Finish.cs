using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
