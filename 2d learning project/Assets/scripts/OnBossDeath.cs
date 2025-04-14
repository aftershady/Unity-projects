using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnBossDeath : MonoBehaviour
{
    public static OnBossDeath instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance OnBossDeath");
        }
        instance = this;
    }
    public void openDoor()
    {
        StartCoroutine(OpenDoor());
    }

    private IEnumerator OpenDoor()
    {
        Vector3 targetPosition = new Vector3(-23f, 24f, 0f);
        yield return new WaitForSeconds(1f);
        if(PlayerHealth.instance.currentHealth <= 0)
        {
            yield break; // Exit if the player is dead
        }
        AudioManager.instance.bossIsDead = true;
        yield return new WaitForSeconds(7.5f);

        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < 2f)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / 2f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Ensure the final position is set
    }
}
