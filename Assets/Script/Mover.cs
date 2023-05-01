using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] 
    float moveSpeed = .2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float zValue = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float xValue = Input.GetAxis("Vertical")* moveSpeed * Time.deltaTime;

        transform.Translate(-xValue, 0, zValue);
    }
}
