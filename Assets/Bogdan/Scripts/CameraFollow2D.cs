using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow2D : MonoBehaviour
{
    public GameObject[] camPoints;
    public int pointIndex;
    public float transitionDuration = 0.5f;



    public void Awake()
    {
        pointIndex = 0;
    }

    IEnumerator Transition(Transform target)
    {
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        Quaternion startingRot = transform.rotation;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);

            transform.position = Vector3.Lerp(startingPos, target.position, t);
            transform.rotation = Quaternion.Lerp(startingRot, target.rotation, t);
            yield return 0;
        }
    }
    public void cameraMove()
    {
        pointIndex++;
        if(pointIndex==4)
        {
            pointIndex = 0;
        }
        StartCoroutine(Transition(camPoints[pointIndex].transform));
    }

    
}


