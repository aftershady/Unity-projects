using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnBossDeath : MonoBehaviour
{
    public GameObject boss;

    void Update()
    {
        if (boss == null)
        {
            StartCoroutine(SmoothTransition(new Vector3(5f, 4f, 0f), 2f));
        }
    }

    private IEnumerator SmoothTransition(Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Ensure the final position is set
    }
}
