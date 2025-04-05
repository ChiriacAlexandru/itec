using System.Collections.Generic;
using UnityEngine;

public class ToggleMovementTrigger : MonoBehaviour
{
    [Header("Player Movement Settings")]
    [SerializeField] private FullCharMovement playerMovement;
    public bool newCanForwardState = true;
    public bool newCanRightState = true;
    public bool newCan2DState = false;

    [Header("Prefabs to Activate")]
    public List<GameObject> prefabsToActivate = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

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
        }
    }
}
