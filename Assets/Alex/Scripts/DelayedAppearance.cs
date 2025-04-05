using UnityEngine;
using System.Collections;

public class DelayedAppearance : MonoBehaviour
{
    public float delayTime = 1f;
    [SerializeField] private GameObject characterToPlay;

    void Start()
    {

        characterToPlay.SetActive(false);
        StartCoroutine(AppearAfterDelay());
    }

    IEnumerator AppearAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        characterToPlay.SetActive(true);
    }
}