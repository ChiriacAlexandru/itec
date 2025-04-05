using System;
using UnityEngine;

public class CornerCheck: MonoBehaviour
{
    public FullCharMovement character;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            character.canRotate2D = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            character.canRotate2D = false;
        }
    }

}
