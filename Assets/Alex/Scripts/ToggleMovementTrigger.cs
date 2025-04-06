using System.Collections.Generic;
using UnityEngine;

public class ToggleMovementTrigger : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public FullCharMovement playerMovement;
    public bool newCanForwardState = true;
    public bool newCanRightState = true;
    public bool newCan2DState = false;
    public GameObject[] walls;
    public GameObject camera2D;
    public GameObject camera3D;
    public GameObject cameraCinemachine;
    public GameObject blackbckg;

    [Header("Objects to Activate")]
    public List<GameObject> objectsToActivate = new List<GameObject>();

    [Header("Objects to Deactivate")]
    public List<GameObject> objectsToDeactivate = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (playerMovement != null)
        {
            playerMovement.canForward = newCanForwardState;
            playerMovement.canRight = newCanRightState;
            playerMovement.can2D = newCan2DState;
        }

        foreach (GameObject wall in walls)
        {
            wall.SetActive(false);
        }
        camera2D.SetActive(false);
        camera3D.SetActive(true);
        cameraCinemachine.SetActive(true);
        blackbckg.SetActive(false);

        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}