using UnityEngine;
using System.Collections;
public class Blinking : MonoBehaviour
{
 
    [Header("References")]
    [SerializeField] private GameObject objectToBlink;
    [SerializeField] private float blinkInterval = 0.5f;

    [Header("Appearance Settings")]
    [SerializeField] private bool startVisible = false;
    [SerializeField] private bool blinkOnStart = false;

    private Coroutine blinkingCoroutine;
    private bool isBlinking = false;

    void Start()
    {
        if (objectToBlink != null)
        {
            objectToBlink.SetActive(startVisible);
        }

        if (blinkOnStart)
        {
            StartBlinking();
        }
    }

    public void ShowAndStartBlinking()
    {
        if (objectToBlink == null) return;

        objectToBlink.SetActive(true);

        if (!isBlinking)
        {
            StartBlinking();
        }
    }

    public void StartBlinking()
    {
        if (isBlinking || objectToBlink == null) return;

        if (blinkingCoroutine != null)
        {
            StopCoroutine(blinkingCoroutine);
        }

        blinkingCoroutine = StartCoroutine(BlinkRoutine());
        isBlinking = true;
    }

    public void StopBlinking()
    {
        if (!isBlinking || objectToBlink == null) return;

        if (blinkingCoroutine != null)
        {
            StopCoroutine(blinkingCoroutine);
        }

        objectToBlink.SetActive(true);
        isBlinking = false;
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            objectToBlink.SetActive(!objectToBlink.activeSelf);

            yield return new WaitForSeconds(blinkInterval);
        }
    }

    public void StopBlinkingAndHide()
    {
        StopBlinking();
        if (objectToBlink != null)
        {
            objectToBlink.SetActive(false);
        }
    }
}

