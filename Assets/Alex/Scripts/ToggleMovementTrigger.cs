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


    [Header("Prefabs to Activate")]
    public List<GameObject> prefabsToActivate = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        /*if (!other.CompareTag("Player")) return;

        if (playerMovement != null)
        {
            playerMovement.canForward = newCanForwardState;
            playerMovement.canRight = newCanRightState;
            playerMovement.can2D = newCan2DState;
        }

        foreach (GameObject prefab in prefabsToActivate)
        {
            if (prefab != null)
            {
                prefab.SetActive(true);
            }
        }*/

        if (other.tag == "Player")
        {
            playerMovement.canForward = true;
            foreach (GameObject wall in walls){
                wall.active = false;
            }
            camera2D.active = false;
            camera3D.active = true;
            cameraCinemachine.active = true;
            blackbckg.active = false;
        }
    }
}
