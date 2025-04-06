using System;
using UnityEngine;

public class CollectStars: MonoBehaviour
{
    public GameObject firstStar;
    public GameObject secondStar;
    public GameObject thirdStar;
    public FullCharMovement character;
    public GameObject skyPlatform;

    public void Start()
    {
        secondStar.active = false;
        character = gameObject.GetComponent<FullCharMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==firstStar)
        {
            character.can2D = true;
            secondStar.active = true;
        }

        if(other.gameObject==secondStar)
        {
            skyPlatform.active = false;
        }

        if (other.gameObject == secondStar)
        {
            character.canRotate2D = true; 
        }
    }
}
