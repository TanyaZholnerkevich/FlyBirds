using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnMove : MonoBehaviour
{
    public float speed = 0.075f;

    private void Start()
    {
        speed = 0.075f;
    }

    private void FixedUpdate()
    { 
        transform.position += new Vector3(speed * (-1), 0, 0);
    }

    public void EndColumnMove()
    {
        speed = 0f;
        Debug.Log("0");
    }
}
