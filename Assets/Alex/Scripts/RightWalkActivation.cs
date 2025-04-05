using UnityEngine;

public class RightWalkActivation : MonoBehaviour
{
    public void SetParentBool()
    {
        GetComponentInParent<FullCharMovement>().canRight = true;
    }
}
