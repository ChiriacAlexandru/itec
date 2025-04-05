using System;
using UnityEngine;

public class CameraFacing :MonoBehaviour
{
    public GameObject camera;
    public void Update()
    {
        transform.forward = camera.transform.forward;
    }

}
