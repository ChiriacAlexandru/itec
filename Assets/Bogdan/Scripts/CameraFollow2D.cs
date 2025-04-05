using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow2D : MonoBehaviour
{
    public GameObject[] camPoints;
    private int pointIndex;

    public void Awake()
    {
        pointIndex = 0;
    }
    public void cameraMove()
    {
        pointIndex++;
        if(pointIndex==5)
        {

        }
        camPoints[pointIndex-1]
    }
}


